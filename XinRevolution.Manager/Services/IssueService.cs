using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using XinRevolution.Entity.Entities;
using XinRevolution.Manager.MetaData;
using XinRevolution.Manager.Models;
using XinRevolution.Repository.Interfaces;

namespace XinRevolution.Manager.Services
{
    public class IssueService : BaseService<IssueEntity, IssueMD>
    {
        private readonly StorageService _service;

        public IssueService(IUnitOfWork<DbContext> unitOfWork, StorageService service) : base(unitOfWork)
        {
            _service = service;
        }

        public override OperationResult<IssueMD> Delete(IssueMD metaData)
        {
            var result = new OperationResult<IssueMD>();

            try
            {
                // 刪除相關連結
                var relativeLinks = _unitOfWork.GetRepository<IssueRelativeLinkEntity>().Find(x => x.IssueId == metaData.Id);
                _unitOfWork.GetRepository<IssueRelativeLinkEntity>().Delete(x => x.IssueId == metaData.Id);
                _service.Delete(relativeLinks.Select(x => x.ResourceUrl));

                // 刪除子議題
                var issueItems = _unitOfWork.GetRepository<IssueItemEntity>().Find(x => x.IssueId == metaData.Id);
                _unitOfWork.GetRepository<IssueItemEntity>().Delete(x => x.IssueId == metaData.Id);
                _service.Delete(issueItems.Select(x => x.ResourceUrl));

                // 刪除議題
                _unitOfWork.GetRepository<IssueEntity>().Delete(ToEntity(metaData));

                if (_unitOfWork.Commit() <= 0)
                    throw new Exception($"無法刪除資料列");

                result.Status = true;
                result.Message = $"操作成功";
                result.Data = metaData;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = $"操作失敗 : {ex.Message}";
                result.Data = metaData;
            }

            return result;
        }

        protected override IssueEntity ToEntity(IssueMD metaData)
        {
            return new IssueEntity
            {
                Id = metaData.Id,
                Name = metaData.Name,
                Intro = metaData.Intro
            };
        }

        protected override IssueMD ToMetaData(IssueEntity entity)
        {
            return new IssueMD
            {
                Id = entity.Id,
                Name = entity.Name,
                Intro = entity.Intro
            };
        }
    }
}

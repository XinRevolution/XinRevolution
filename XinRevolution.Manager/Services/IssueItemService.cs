using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XinRevolution.Entity.Entities;
using XinRevolution.Manager.MetaData;
using XinRevolution.Manager.Models;
using XinRevolution.Repository.Interfaces;

namespace XinRevolution.Manager.Services
{
    public class IssueItemService : BaseService<IssueItemEntity, IssueItemMD>
    {
        private readonly StorageService _service;
        private readonly string _containerName = "IssueItem";

        public IssueItemService(IUnitOfWork<DbContext> unitOfWork, StorageService service) : base(unitOfWork)
        {
            _service = service;
        }

        public OperationResult<List<IssueItemEntity>> FindAll(int issueId)
        {
            var result = new OperationResult<List<IssueItemEntity>>();

            try
            {
                var entities = _unitOfWork.GetRepository<IssueItemEntity>().Find(x => x.IssueId == issueId).ToList();

                result.Status = true;
                result.Message = $"操作成功";
                result.Data = entities;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = $"操作失敗 : {ex.Message}";
                result.Data = null;
            }

            return result;
        }

        public override OperationResult<IssueItemMD> Create(IssueItemMD metaData)
        {
            var result = new OperationResult<IssueItemMD>();

            try
            {
                var uploadResult = _service.Save(_containerName, metaData.ResourceFile);
                if (!uploadResult.Status)
                    throw new Exception(uploadResult.Message);

                metaData.ResourceUrl = uploadResult.Data;

                _unitOfWork.GetRepository<IssueItemEntity>().Add(ToEntity(metaData));

                if (_unitOfWork.Commit() <= 0)
                    throw new Exception($"無法新增資料列");

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

        public override OperationResult<IssueItemMD> Update(IssueItemMD metaData)
        {
            var result = new OperationResult<IssueItemMD>();

            try
            {
                if (metaData.ResourceFile != null)
                {
                    var resourceUrl = metaData.ResourceUrl;
                    var uploadResult = _service.Save(_containerName, metaData.ResourceFile);
                    if (!uploadResult.Status)
                        throw new Exception(uploadResult.Message);

                    _service.Delete(metaData.ResourceUrl);

                    metaDa
                }
            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public override OperationResult<IssueItemMD> Delete(IssueItemMD metaData)
        {
            var result = new OperationResult<IssueItemMD>();

            try
            {

            }
            catch (Exception ex)
            {

            }

            return result;
        }

        protected override IssueItemEntity ToEntity(IssueItemMD metaData)
        {
            return new IssueItemEntity
            {
                Id = metaData.Id,
                Title = metaData.Title,
                ReleaseDate = metaData.ReleaseDate,
                Content = metaData.Content,
                ResourceUrl = metaData.ResourceUrl,
                IssueId = metaData.IssueId
            };
        }

        protected override IssueItemMD ToMetaData(IssueItemEntity entity)
        {
            return new IssueItemMD
            {
                Id = entity.Id,
                Title = entity.Title,
                ReleaseDate = entity.ReleaseDate,
                Content = entity.Content,
                ResourceUrl = entity.ResourceUrl,
                IssueId = entity.IssueId,
                ResourceName = entity.ResourceUrl
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XinRevolution.Entity.Model;
using XinRevolution.Repository.Interface;
using XinRevolution.Web.Models.Management.MetaData;
using XinRevolution.Web.Models.ViewModel.Management;

namespace XinRevolution.Web.Services.Management
{
    public class IssueManagementService
    {
        private readonly IIssueRepository _repository;

        public IssueManagementService(IIssueRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<IssueModel> Find()
        {
            var result = _repository.FindAll();

            return result;
        }

        public IssueMD FindMetaData(long id = -1)
        {
            return id == -1 ? new IssueMD() : ToMetaData(_repository.FindById(id));
        }

        public Result<IssueMD> Create(IssueMD data)
        {
            var result = new Result<IssueMD>();

            try
            {
                result.Status = _repository.Create(ToModel(data));
                result.Message = "新增成功";
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = $"新增失敗 : {ex.Message}";
                result.Data = data;
            }

            return result;
        }

        public Result<IssueMD> Update(IssueMD data)
        {
            var result = new Result<IssueMD>();

            try
            {
                result.Status = _repository.Update(ToModel(data));
                result.Message = "更新成功";
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = $"更新失敗 : {ex.Message}";
                result.Data = data;
            }

            return result;
        }

        public Result<IssueMD> Delete(IssueMD data)
        {
            var result = new Result<IssueMD>();

            try
            {
                result.Status = _repository.Delete(ToModel(data));
                result.Message = "刪除成功";

                // TODO : IssueItemRepository.Delete() 
                // TODO : IssueRelativeLinkRepository.Delete()
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = $"刪除失敗 : {ex.Message}";
                result.Data = data;
            }

            return result;
        }

        private IssueMD ToMetaData(IssueModel model)
        {
            return new IssueMD
            {
                Id = model.Id,
                IssueName = model.IssueName,
                Intro = model.Intro
            };
        }

        private IssueModel ToModel(IssueMD metaData)
        {
            return new IssueModel
            {
                Id = metaData.Id,
                IssueName = metaData.IssueName,
                Intro = metaData.Intro
            };
        }
    }
}

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
    public class TagManagementService
    {
        private readonly ITagRepository _repository;

        public TagManagementService(ITagRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<TagModel> Find()
        {
            var result = _repository.FindAll();

            return result;
        }

        public TagMD FindMetaData(long id = -1)
        {
            return id == -1 ? new TagMD() : ToMetaData(_repository.FindById(id));
        }

        public Result<TagMD> Create(TagMD data)
        {
            var result = new Result<TagMD>();

            try
            {
                result.Status = _repository.Create(ToModel(data));
                result.Message = "新增成功";
            }
            catch(Exception ex)
            {
                result.Status = false;
                result.Message = $"新增失敗 : {ex.Message}";
                result.Data = data;
            }

            return result;
        }

        public Result<TagMD> Update(TagMD data)
        {
            var result = new Result<TagMD>();

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

        public Result<TagMD> Delete(TagMD data)
        {
            var result = new Result<TagMD>();

            try
            {
                result.Status = _repository.Delete(ToModel(data));
                result.Message = "刪除成功";
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = $"刪除失敗 : {ex.Message}";
                result.Data = data;
            }

            return result;
        }

        private TagMD ToMetaData(TagModel model)
        {
            return new TagMD
            {
                Id = model.Id,
                Name = model.Name,
                Status = model.Status
            };
        } 

        private TagModel ToModel(TagMD metaData)
        {
            return new TagModel
            {
                Id = metaData.Id,
                Name = metaData.Name,
                Status = metaData.Status
            };
        }
    }
}

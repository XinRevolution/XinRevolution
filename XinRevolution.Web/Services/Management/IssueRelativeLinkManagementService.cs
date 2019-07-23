using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using XinRevolution.Entity.Model;
using XinRevolution.Repository.Interface;
using XinRevolution.Web.Models.Management.Constants;
using XinRevolution.Web.Models.Management.MetaData;
using XinRevolution.Web.Models.ViewModel.Management;

namespace XinRevolution.Web.Services.Management
{
    public class IssueRelativeLinkManagementService
    {
        private readonly FileManagementService _fileService;
        private readonly IIssueRelativeLinkRepository _repository;
        private readonly string _rootPath;
        private readonly string _folderPath;

        public IssueRelativeLinkManagementService(FileManagementService fileService, IIssueRelativeLinkRepository repository, IHostingEnvironment enviroment)
        {
            _fileService = fileService;
            _repository = repository;
            _rootPath = enviroment.ContentRootPath;
            _folderPath = Path.Combine(_rootPath, FolderConfiguration.IssueRelativeLinkImages);
        }

        public IEnumerable<IssueRelativeLinkModel> FindByIssueID(long issueId)
        {
            var result = _repository.FindByIssueID(issueId);

            return result;
        }

        public IssueRelativeLinkMD FindMetaData(long id = -1)
        {
            return id == -1 ? new IssueRelativeLinkMD() : ToMetaData(_repository.FindById(id));
        }



        // To Implement

        public Result<IssueRelativeLinkMD> Create(IssueRelativeLinkMD data)
        {
            var result = new Result<IssueRelativeLinkMD>();
            var ioResult = new Result<string>();

            try
            {
                if (data.UploadFile == null || data.UploadFile.Length <= 0)
                    throw new Exception($"請上傳檔案");

                ioResult = _fileService.Save(_folderPath, data.UploadFile);
                if (!ioResult.Status)
                    throw new Exception(ioResult.Message);

                data.ResourceName = ioResult.Data;
                data.ResourceVirtualPath = GetVirtualPath(ioResult.Data);

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

        public Result<IssueRelativeLinkMD> Update(IssueRelativeLinkMD data)
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

        public Result<IssueRelativeLinkMD> Delete(IssueRelativeLinkMD data)
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

        public Result<long> DeleteByIssueID(long issueId)
        {
            throw new NotImplementedException();
        }



        private string GetVirtualPath(string fileName)
        {
            return Path.Combine(_rootPath, FolderConfiguration.IssueRelativeLinkImages, fileName);
        }

        public IssueRelativeLinkMD ToMetaData(IssueRelativeLinkModel model)
        {
            return new IssueRelativeLinkMD
            {
                IssueId = model.IssueId,
                Id = model.Id,
                ResourceName = model.ResourceName,
                Url = model.Url,
                Note = model.Note,
                ResourceVirtualPath = model.ResourceVirtualPath,
                UploadFileName = model.ResourceName
            };
        }

        public IssueRelativeLinkModel ToModel(IssueRelativeLinkMD metaData)
        {
            return new IssueRelativeLinkModel
            {
                IssueId = metaData.IssueId,
                Id = metaData.Id,
                ResourceName = metaData.ResourceName,
                Url = metaData.Url,
                Note = metaData.Note,
                ResourceVirtualPath = metaData.ResourceVirtualPath
            };
        }
    }
}

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

namespace XinRevolution.Web.Services.Management
{
    public class IssueRelativeLinkManagementService
    {
        private readonly FileManagementService _fileService;
        private readonly IIssueRelativeLinkRepository _repository;
        private readonly string _folderPath;

        public IssueRelativeLinkManagementService(FileManagementService fileService, IIssueRelativeLinkRepository repository, IHostingEnvironment enviroment)
        {
            _fileService = fileService;
            _repository = repository;
            _folderPath = Path.Combine(enviroment.WebRootPath, FolderConfiguration.IssueRelativeLinkImages);
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

        // To be completed
        public IssueRelativeLinkMD ToMetaData(IssueRelativeLinkModel model)
        {
            return new IssueRelativeLinkMD
            {
                Id = model.Id,
                IssueId = model.IssueId
            };
        }
    }
}

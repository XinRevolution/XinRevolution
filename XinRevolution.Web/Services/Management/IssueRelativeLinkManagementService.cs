using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using XinRevolution.Entity.Model;
using XinRevolution.Repository.Interface;
using XinRevolution.Web.Models.Management.MetaData;
using XinRevolution.Web.Models.ViewModel.Management;

namespace XinRevolution.Web.Services.Management
{
    public class IssueRelativeLinkManagementService
    {
        private readonly IIssueRelativeLinkRepository _repository;

        public IssueRelativeLinkManagementService(IIssueRelativeLinkRepository repository)
        {
            _repository = repository;
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
            throw new NotImplementedException();
        }

        public Result<IssueRelativeLinkMD> Update(IssueRelativeLinkMD data)
        {
            throw new NotImplementedException();
        }

        public Result<IssueRelativeLinkMD> Delete(IssueRelativeLinkMD data)
        {
            throw new NotImplementedException();
        }

        public Result<long> DeleteByIssueID(long issueId)
        {
            throw new NotImplementedException();
        }



        private string GetVirtualPath(string fileName)
        {
            throw new NotImplementedException();
        }

        public IssueRelativeLinkMD ToMetaData(IssueRelativeLinkModel model)
        {
            throw new NotImplementedException();
        }

        public IssueRelativeLinkModel ToModel(IssueRelativeLinkMD metaData)
        {
            throw new NotImplementedException();
        }
    }
}

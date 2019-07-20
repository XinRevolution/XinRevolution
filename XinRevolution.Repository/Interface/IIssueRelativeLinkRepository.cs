using System;
using System.Collections.Generic;
using System.Text;
using XinRevolution.Entity.Model;

namespace XinRevolution.Repository.Interface
{
    public interface IIssueRelativeLinkRepository : IBaseRepository<IssueRelativeLinkModel>
    {
        IEnumerable<IssueRelativeLinkModel> FindByIssueID(long issueId);

        bool DeleteByIssueID(long issueID);
    }
}

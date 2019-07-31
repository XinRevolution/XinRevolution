using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using XinRevolution.Entity.Context;
using XinRevolution.Entity.Model;
using XinRevolution.Repository.Interface;

namespace XinRevolution.Repository.Repository
{
    public class IssueRelativeLinkRepository : BaseRepository, IIssueRelativeLinkRepository
    {
        public IssueRelativeLinkRepository(XinRevolutionDbContext context) : base(context)
        {
        }

        public IEnumerable<IssueRelativeLinkModel> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IssueRelativeLinkModel> FindAll(Expression<Func<IssueRelativeLinkModel, bool>> expression)
        {
            return _context.IssueRelativeLinks.Where(expression).ToList();
        }

        public IssueRelativeLinkModel FindById(long id)
        {
            return _context.IssueRelativeLinks.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<IssueRelativeLinkModel> FindByIssueID(long issueId)
        {
            return _context.IssueRelativeLinks.Where(x => x.IssueId == issueId).ToList();
        }

        public bool Create(IssueRelativeLinkModel entity)
        {
            _context.IssueRelativeLinks.Add(entity);
            _context.SaveChanges();

            return true;
        }

        public bool Update(IssueRelativeLinkModel entity)
        {
            var origin = _context.IssueRelativeLinks.SingleOrDefault(x => x.Id == entity.Id);

            if (origin == default(IssueRelativeLinkModel))
                throw new Exception($"無法取得原始資料 (IssueRelativeLink.Id = {entity.Id})");

            _context.Entry(origin).CurrentValues.SetValues(entity);
            _context.SaveChanges();

            return true;
        }

        public bool Delete(IssueRelativeLinkModel entity)
        {
            var origin = _context.IssueRelativeLinks.SingleOrDefault(x => x.Id == entity.Id);

            if (origin == default(IssueRelativeLinkModel))
                throw new Exception($"無法取得原始資料 (IssueRelativeLink.Id = {entity.Id})");

            _context.IssueRelativeLinks.Remove(entity);
            _context.SaveChanges();

            return true;
        }

        public bool DeleteByIssueID(long issueID)
        {
            //var entities = _context.IssueRelativeLinks.Where(x => x.IssueId == issueID);

            //_context.IssueRelativeLinks.RemoveRange(entities);
            //_context.SaveChanges();

            //return true;
            throw new NotImplementedException();
        }
    }
}

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
    public class IssueRepository : BaseRepository, IIssueRepository
    {
        public IssueRepository(XinRevolutionDbContext context) : base(context)
        {

        }

        public IEnumerable<IssueModel> FindAll()
        {
            return _context.Issues.ToList();
        }

        public IEnumerable<IssueModel> FindAll(Expression<Func<IssueModel, bool>> expression)
        {
            return _context.Issues.Where(expression).ToList();
        }

        public IssueModel FindById(long id)
        {
            return _context.Issues.SingleOrDefault(x => x.Id == id);
        }

        public bool Create(IssueModel entity)
        {
            _context.Issues.Add(entity);
            _context.SaveChanges();

            return true;
        }

        public bool Update(IssueModel entity)
        {
            var origin = _context.Issues.SingleOrDefault(x => x.Id == entity.Id);

            if (origin == default(IssueModel))
                throw new Exception($"無法取得原始資料 (Issue.Id = {entity.Id})");

            _context.Entry(origin).CurrentValues.SetValues(entity);
            _context.SaveChanges();

            return true;
        }

        public bool Delete(IssueModel entity)
        {
            var origin = _context.Issues.SingleOrDefault(x => x.Id == entity.Id);

            if (origin == default(IssueModel))
                throw new Exception($"無法取得原始資料 (Issue.Id = {entity.Id})");

            _context.Issues.Remove(origin);
            _context.SaveChanges();

            return true;
        }
    }
}

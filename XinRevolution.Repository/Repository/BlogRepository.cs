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
    public class BlogRepository : IRepository<BlogModel, string, string>
    {
        private readonly XinRevolutionDbContext _context;

        private XinRevolutionDbContext Context { get { return _context; } }

        public BlogRepository(XinRevolutionDbContext context)
        {
            _context = context;
        }

        public BlogModel Create(BlogModel entity)
        {
            Context.Blogs.Add(entity);
            Context.SaveChanges();

            return entity;
        }

        public BlogModel Update(BlogModel entity)
        {
            var blog = FindById(entity.Id);

            if (blog == default(BlogModel))
                throw new Exception($"無法取得部落格資料 (ID = {entity.Id})");

            Context.Entry(blog).CurrentValues.SetValues(entity);
            Context.SaveChanges();

            return entity;
        }

        public bool DeleteById(long id)
        {
            var blog = FindById(id);

            if (blog == default(BlogModel))
                throw new Exception($"無法取得部落格資料 (ID = {id})");

            Context.Blogs.Remove(blog);
            Context.SaveChanges();

            return true;
        }

        public bool DeleteByKey(string key1, string key2)
        {
            var blog = FindByKey(key1, key2);

            if (blog == default(BlogModel))
                throw new Exception($"無法取得部落格資料 (Key1 = {key1} , Key2 = {key2})");

            Context.Blogs.Remove(blog);
            Context.SaveChanges();

            return true;
        }

        public BlogModel FindById(long id)
        {
            return Context.Blogs.SingleOrDefault(x => x.Id == id);
        }

        public BlogModel FindByKey(string key1, string key2)
        {
            return Context.Blogs.SingleOrDefault(x => x.Title.Equals(key1) && x.Date.Equals(key2));
        }

        public IEnumerable<BlogModel> Find(Expression<Func<BlogModel, bool>> expression)
        {
            return Context.Blogs.Where(expression);
        }
    }
}

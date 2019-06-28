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
    public class TagRepository : IRepository<TagModel, string>
    {
        private readonly XinRevolutionDbContext _context;

        private XinRevolutionDbContext Context { get { return _context; } }

        public TagRepository(XinRevolutionDbContext context)
        {
            _context = context;
        }

        public TagModel Create(TagModel entity)
        {
            Context.Tags.Add(entity);
            Context.SaveChanges();

            return entity;
        }

        public TagModel Update(TagModel entity)
        {
            var tag = FindbyId(entity.Id);

            if (tag == default(TagModel))
                throw new Exception($"無法取得標籤資料 (ID = {entity.Id})");

            Context.Entry(tag).CurrentValues.SetValues(entity);
            Context.SaveChanges();

            return entity;
        }

        public bool DeleteById(long id)
        {
            var tag = FindbyId(id);

            if (tag == default(TagModel))
                throw new Exception($"無法取得標籤資料 (ID = {id})");

            Context.Tags.Remove(tag);
            Context.SaveChanges();

            return true;
        }

        public bool DeleteByKey(string key)
        {
            var tag = FindByKey(key);

            if (tag == default(TagModel))
                throw new Exception($"無法取得標籤資料 (key = {key})");

            Context.Tags.Remove(tag);
            Context.SaveChanges();

            return true;
        }

        public TagModel FindbyId(long id)
        {
            return Context.Tags.SingleOrDefault(x => x.Id == id);
        }

        public TagModel FindByKey(string key)
        {
            return Context.Tags.SingleOrDefault(x => x.TagName.Equals(key));
        }

        public IEnumerable<TagModel> Find(Expression<Func<TagModel, bool>> expression)
        {
            return Context.Tags.Where(expression);
        }
    }
}

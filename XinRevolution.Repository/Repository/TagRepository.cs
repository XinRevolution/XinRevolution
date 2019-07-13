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
    public class TagRepository : BaseRepository, ITagRepository
    {
        public TagRepository(XinRevolutionDbContext context) : base(context)
        {
        }

        public IEnumerable<TagModel> FindAll()
        {
            return _context.Tags.ToList();
        }

        public IEnumerable<TagModel> FindAll(Expression<Func<TagModel, bool>> expression)
        {
            return _context.Tags.Where(expression).ToList();
        }

        public TagModel FindById(long id)
        {
            return _context.Tags.SingleOrDefault(x => x.Id == id);
        }

        public bool Create(TagModel entity)
        {
            _context.Tags.Add(entity);
            _context.SaveChanges();

            return true;
        }

        public bool Update(TagModel entity)
        {
            var origin = _context.Tags.SingleOrDefault(x => x.Id == entity.Id);

            if (origin == default(TagModel))
                throw new Exception($"無法取得原始資料 (Tag.Id = {entity.Id})");

            _context.Entry(origin).CurrentValues.SetValues(entity);
            _context.SaveChanges();

            return true;
        }

        public bool Delete(TagModel entity)
        {
            var origin = _context.Tags.SingleOrDefault(x => x.Id == entity.Id);

            if (origin == default(TagModel))
                throw new Exception($"無法取得原始資料 (Tag.Id = {entity.Id})");

            _context.Tags.Remove(origin);
            _context.SaveChanges();

            return true;
        }
    }
}

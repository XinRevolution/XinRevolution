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
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(XinRevolutionDbContext context) : base(context)
        {
        }

        public IEnumerable<UserModel> FindAll()
        {
            return _context.Users.ToList();
        }

        public IEnumerable<UserModel> FindAll(Expression<Func<UserModel, bool>> expression)
        {
            return _context.Users.Where(expression).ToList();
        }

        public UserModel FindById(long id)
        {
            return _context.Users.SingleOrDefault(x => x.Id == id);
        }

        public UserModel FindByKey(string key)
        {
            return _context.Users.SingleOrDefault(x => x.Account.Equals(key));
        }

        public bool Create(UserModel entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();

            return true;
        }

        public bool Update(UserModel entity)
        {
            var origin = _context.Users.SingleOrDefault(x => x.Id == entity.Id);

            if (origin == default(UserModel))
                throw new Exception($"無法取得原始資料 (User.Id = {entity.Id})");

            _context.Entry(origin).CurrentValues.SetValues(entity);
            _context.SaveChanges();

            return true;
        }

        public bool Delete(UserModel entity)
        {
            var origin = _context.Users.SingleOrDefault(x => x.Id == entity.Id);

            if (origin == default(UserModel))
                throw new Exception($"無法取得原始資料 (User.Id = {entity.Id})");

            _context.Users.Remove(origin);
            _context.SaveChanges();

            return true;
        }
    }
}

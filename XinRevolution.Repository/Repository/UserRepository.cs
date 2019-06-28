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
    public class UserRepository : IRepository<UserModel, string>
    {
        private readonly XinRevolutionDbContext _context;

        private XinRevolutionDbContext Context { get { return _context; } }

        public UserRepository(XinRevolutionDbContext context)
        {
            _context = context;
        }
        
        public UserModel Create(UserModel entity)
        {
            Context.Users.Add(entity);
            Context.SaveChanges();

            return entity;
        }

        public UserModel Update(UserModel entity)
        {
            var user = FindbyId(entity.Id);

            if (user == default(UserModel))
                throw new Exception($"無法取得使用者資料 (ID = {entity.Id})");

            Context.Entry(user).CurrentValues.SetValues(entity);
            Context.SaveChanges();

            return entity;
        }

        public bool DeleteById(long id)
        {
            var user = FindbyId(id);

            if (user == default(UserModel))
                throw new Exception($"無法取得使用者資料 (ID = {id})");

            Context.Users.Remove(user);
            Context.SaveChanges();

            return true;
        }

        public bool DeleteByKey(string key)
        {
            var user = FindByKey(key);

            if (user == default(UserModel))
                throw new Exception($"無法取得使用者資料 (Key = {key})");

            Context.Users.Remove(user);
            Context.SaveChanges();

            return true;
        }

        public UserModel FindbyId(long id)
        {
            return Context.Users.SingleOrDefault(x => x.Id == id);
        }

        public UserModel FindByKey(string key)
        {
            return Context.Users.SingleOrDefault(x => x.Account.Equals(key));
        }

        public IEnumerable<UserModel> Find(Expression<Func<UserModel, bool>> expression)
        {
            return Context.Users.Where(expression);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using XinRevolution.Entity.Context;
using XinRevolution.Entity.Models;
using XinRevolution.Repositories.Interfaces;

namespace XinRevolution.Entity.Repositories
{
    public class UserRepository : IRepository<UserModel, string>
    {
        private readonly XinRevolutionDbContext _context;

        public UserRepository(XinRevolutionDbContext context)
        {
            _context = context;
        }

        public XinRevolutionDbContext Context { get { return this._context; } }

        public UserModel Create(UserModel entity)
        {
            Context.Users.Add(entity);
            Context.SaveChanges();

            return entity;
        }
               
        public UserModel Update(UserModel entity)
        {
            var originUser = FindbyId(entity.Id);

            if(originUser == default(UserModel))
                throw new Exception($"無法取得 User 物件 ( Id = {entity.Id} )");

            Context.Entry(originUser).CurrentValues.SetValues(entity);
            Context.SaveChanges();

            return entity;
        }

        public bool DeleteById(long id)
        {
            var entity = Context.Users.SingleOrDefault(x => x.Id == id);

            if (entity == default(UserModel))
                throw new Exception($"無法取得 User 物件 ( Id = {id} )");

            Context.Users.Remove(entity);
            Context.SaveChanges();

            return true;
        }

        public bool DeleteByKey(string key)
        {
            var entity = Context.Users.SingleOrDefault(x => x.Account.Equals(key));
            
            if (entity == default(UserModel))
                throw new Exception($"無法取得 User 物件 ( Accont = {key} )");

            Context.Users.Remove(entity);
            Context.SaveChanges();

            return true;
        }
        
        public UserModel FindbyId(long id)
        {
            var entity = Context.Users.SingleOrDefault(x => x.Id == id);

            return entity;
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

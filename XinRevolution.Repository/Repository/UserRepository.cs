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
    public class UserRepository : BaseRepository, IUserRepository<UserModel>
    {
        public UserRepository(XinRevolutionDbContext context) : base(context)
        {
        }

        public IEnumerable<UserModel> FindAll()
        {
            return Context.Users.ToList();
        }

        public IEnumerable<UserModel> FindAll(Expression<Func<UserModel, bool>> expression)
        {
            return Context.Users.Where(expression).ToList();
        }

        public UserModel FindByID(long id)
        {
            return Context.Users.SingleOrDefault(x => x.Id == id);
        }

        public UserModel FindByKey(string key)
        {
            return Context.Users.SingleOrDefault(x => x.Account.Equals(key, StringComparison.CurrentCultureIgnoreCase));
        }

        public UserModel Create(UserModel entity)
        {
            Context.Users.Add(entity);
            Context.SaveChanges();

            return entity;
        }

        public UserModel Update(UserModel entity)
        {
            var origin = Context.Users.SingleOrDefault(x => x.Id == entity.Id);

            if (origin == default(UserModel))
                throw new Exception($"無法取得原始資料 [Id = {entity.Id}]");

            Context.Entry(origin).CurrentValues.SetValues(entity);
            Context.SaveChanges();

            return entity;
        }

        public long Delete(long id)
        {
            var origin = Context.Users.SingleOrDefault(x => x.Id == id);

            if (origin == default(UserModel))
                throw new Exception($"無法取得原始資料 [Id = {id}]");

            Context.Users.Remove(origin);
            Context.SaveChanges();

            return id;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using XinRevolution.Entity.Models;

namespace XinRevolution.Entity.Repositories
{
    public class UserRepository : IRepository<UserModel, string>
    {
        private readonly XinRevolutionDbContext _context;

        public XinRevolutionDbContext Context { get { return this._context; } }

        public UserRepository(XinRevolutionDbContext context)
        {
            _context = context;
        }

        public long Create(UserModel entity)
        {
            Context.Users.Add(entity);
            Context.SaveChanges();

            return entity.ID;
        }

        public void Update(UserModel entity)
        {
            var originUser = Context.Users.Single(x => x.ID == entity.ID);
            Context.Entry(originUser).CurrentValues.SetValues(entity);
            Context.SaveChanges();

            return;
        }

        public UserModel FindByKey(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserModel> Find(Expression<Func<UserModel, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}

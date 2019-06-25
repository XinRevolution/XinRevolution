using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace XinRevolution.Entity.Repositories
{
    public interface IRepository<TEntity, TKey> where TEntity : class
    {
        long Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(TKey id);

        TEntity FindByKey(TKey id);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression);
    }
}

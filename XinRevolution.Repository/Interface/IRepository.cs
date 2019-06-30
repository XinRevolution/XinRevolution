using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace XinRevolution.Repository.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Create(TEntity entity);

        TEntity FindById(long id);

        IEnumerable<TEntity> Find();

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression);
    }

    public interface IRepository<TEntity, TKey> where TEntity : class
    {
        TEntity Create(TEntity entity);

        TEntity Update(TEntity entity);

        bool DeleteById(long id);

        bool DeleteByKey(TKey key);

        TEntity FindbyId(long id);

        TEntity FindByKey(TKey key);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression);
    }
}

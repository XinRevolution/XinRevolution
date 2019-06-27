using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace XinRevolution.Repository.Interface
{
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

    public interface IRepository<TEntity, TKey1, TKey2> where TEntity : class
    {
        TEntity Create(TEntity entity);

        TEntity Update(TEntity entity);

        bool DeleteById(long id);

        bool DeleteByKey(TKey1 key1, TKey2 key2);

        TEntity FindById(long id);

        TEntity FindByKey(TKey1 key1, TKey2 key2);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression);
    }
}

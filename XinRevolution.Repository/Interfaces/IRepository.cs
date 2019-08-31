using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace XinRevolution.Repository.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        IEnumerable<TEntity> Find();

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> condition);

        TEntity Single(Expression<Func<TEntity, bool>> condition);



        TEntity Add(TEntity entity);

        void Add(IEnumerable<TEntity> entities);



        void Delete(TEntity entity);

        void Delete(Expression<Func<TEntity, bool>> condition);



        void Update(TEntity entity);
    }
}

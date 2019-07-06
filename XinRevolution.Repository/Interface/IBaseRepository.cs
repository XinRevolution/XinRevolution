using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace XinRevolution.Repository.Interface
{
    public interface IBaseRepository<TEntity>
    {
        IEnumerable<TEntity> FindAll();

        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> expression);

        TEntity FindByID(long id);

        TEntity Create(TEntity entity);

        TEntity Update(TEntity entity);

        long Delete(long id);
    }
}

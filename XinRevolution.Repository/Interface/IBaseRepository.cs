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

        TEntity FindById(long id);

        bool Create(TEntity entity);

        bool Update(TEntity entity);

        bool Delete(TEntity entity);
    }
}

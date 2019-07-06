using System;
using System.Collections.Generic;
using System.Text;

namespace XinRevolution.Repository.Interface
{
    public interface IUserRepository<TEntity> : IBaseRepository<TEntity>
    {
        TEntity FindByKey(string key);
    }
}

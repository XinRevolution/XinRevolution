using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;

namespace XinRevolution.UnitOfWork.Interfaces
{
    public interface IUnitOfWork<TContext> : IDisposable where TContext : DbContext
    {
        TContext Context { get; set; }

        Hashtable Repositories { get; set; }

        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

        int Commit();
    }
}

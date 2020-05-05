using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using XinRevolution.Entity.Entities;

namespace XinRevolution.Repository.Interfaces
{
    public interface IUnitOfWork<TContext> : IDisposable where TContext : DbContext
    {
        TContext Context { get; set; }

        Hashtable Repositories { get; set; }

        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;

        int Commit();
    }
}

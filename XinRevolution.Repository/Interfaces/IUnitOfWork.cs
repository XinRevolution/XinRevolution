using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace XinRevolution.Repository.Interfaces
{
    public interface IUnitOfWork<TContext> where TContext : DbContext
    {
        TContext Context { get; set; }

        Hashtable Repositories { get; set; }

        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

        int Commit();
    }
}

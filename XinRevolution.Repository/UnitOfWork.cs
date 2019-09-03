using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using XinRevolution.Entity;
using XinRevolution.Repository.Interfaces;

namespace XinRevolution.Repository
{
    public class UnitOfWork : IUnitOfWork<DbContext>
    {
        public DbContext Context { get; set; }
        public Hashtable Repositories { get; set; }

        public UnitOfWork(XinRevolutionDbContext context)
        {
            Context = context;
        }

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (Repositories == null)
                Repositories = new Hashtable();

            var key = typeof(TEntity).Name;

            if (Repositories.ContainsKey(key))
                return (IGenericRepository<TEntity>)Repositories[key];

            var repository = new GenericRepository<TEntity>(this);

            Repositories.Add(key, repository);

            return repository;
        }

        public int Commit()
        {
            return Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
            GC.SuppressFinalize(true);
        }
    }
}

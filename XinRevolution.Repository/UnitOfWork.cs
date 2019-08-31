using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using XinRevolution.Entity;
using XinRevolution.Repository.Interfaces;

namespace XinRevolution.Repository
{
    public class UnitOfWork : IUnitOfWork<XinRevolutionDbContext>
    {
        public XinRevolutionDbContext Context { get; set; }

        public UnitOfWork(XinRevolutionDbContext DbContext)
        {
            Context = DbContext;
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            return new GenericRepository<TEntity>(this);
        }

        public int Commit()
        {
            return Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

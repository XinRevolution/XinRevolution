﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using XinRevolution.Entity.Entities;

namespace XinRevolution.Repository.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
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

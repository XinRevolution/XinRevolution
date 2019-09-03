using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using XinRevolution.Repository.Interfaces;

namespace XinRevolution.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly IUnitOfWork<DbContext> _unitOfWork;

        public GenericRepository(IUnitOfWork<DbContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<TEntity> Find()
        {
            return _unitOfWork.Context.Set<TEntity>().AsEnumerable<TEntity>();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> condition)
        {
            return _unitOfWork.Context.Set<TEntity>().Where(condition).AsEnumerable<TEntity>();
        }

        public TEntity Single(Expression<Func<TEntity, bool>> condition)
        {
            return _unitOfWork.Context.Set<TEntity>().SingleOrDefault(condition);
        }

        public TEntity Add(TEntity entity)
        {
            _unitOfWork.Context.Set<TEntity>().Add(entity);

            return entity;
        }

        public void Add(IEnumerable<TEntity> entities)
        {
            _unitOfWork.Context.Set<TEntity>().AddRange(entities);
        }

        public void Delete(TEntity entity)
        {
            var existEntity = _unitOfWork.Context.Set<TEntity>().Find(entity);

            if (existEntity != default(TEntity))
                _unitOfWork.Context.Set<TEntity>().Remove(existEntity);
        }

        public void Delete(Expression<Func<TEntity, bool>> condition)
        {
            var existEntities = _unitOfWork.Context.Set<TEntity>().Where(condition);

            if (existEntities.Count() > 0)
                _unitOfWork.Context.Set<TEntity>().RemoveRange(existEntities);
        }

        public void Update(TEntity entity)
        {
            _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
            _unitOfWork.Context.Set<TEntity>().Attach(entity);
        }
    }
}

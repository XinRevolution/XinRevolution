using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using XinRevolution.Entity.Entities;
using XinRevolution.Manager.Models;
using XinRevolution.Repository.Interfaces;

namespace XinRevolution.Manager.Services
{
    public abstract class BaseService<TEntity, TMetaData>
        where TEntity : BaseEntity, new()
        where TMetaData : class
    {
        protected readonly IUnitOfWork<DbContext> _unitOfWork;

        public BaseService(IUnitOfWork<DbContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public virtual OperationResult<List<TEntity>> FindAll()
        {
            var result = new OperationResult<List<TEntity>>();

            try
            {
                var entities = _unitOfWork.GetRepository<TEntity>().Find().ToList();

                result.Status = true;
                result.Message = $"操作成功";
                result.Data = entities;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = $"操作失敗 : {ex.Message}";
                result.Data = null;
            }

            return result;
        }

        public virtual OperationResult<TMetaData> FindMetaData(int id = -1)
        {
            OperationResult<TMetaData> result = new OperationResult<TMetaData>();

            try
            {
                var entity = id == -1 ? new TEntity() : _unitOfWork.GetRepository<TEntity>().Single(x => x.Id == id);

                result.Status = true;
                result.Message = $"操作成功";
                result.Data = ToMetaData(entity);
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = $"操作失敗 : {ex.Message}";
                result.Data = null;
            }

            return result;
        }

        public virtual OperationResult<TMetaData> Create(TMetaData metaData)
        {
            OperationResult<TMetaData> result = new OperationResult<TMetaData>();

            try
            {
                _unitOfWork.GetRepository<TEntity>().Add(ToEntity(metaData));

                if (_unitOfWork.Commit() <= 0)
                    throw new Exception($"無法新增資料列");

                result.Status = true;
                result.Message = $"操作成功";
                result.Data = metaData;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = $"操作失敗 : {ex.Message}";
                result.Data = metaData;
            }

            return result;
        }

        public virtual OperationResult<TMetaData> Update(TMetaData metaData)
        {
            OperationResult<TMetaData> result = new OperationResult<TMetaData>();

            try
            {
                _unitOfWork.GetRepository<TEntity>().Update(ToEntity(metaData));

                if (_unitOfWork.Commit() <= 0)
                    throw new Exception($"無法更新資料列");

                result.Status = true;
                result.Message = $"操作成功";
                result.Data = metaData;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = $"操作失敗 : {ex.Message}";
                result.Data = metaData;
            }

            return result;
        }

        public virtual OperationResult<TMetaData> Delete(TMetaData metaData)
        {
            OperationResult<TMetaData> result = new OperationResult<TMetaData>();

            try
            {
                _unitOfWork.GetRepository<TEntity>().Delete(ToEntity(metaData));

                if (_unitOfWork.Commit() <= 0)
                    throw new Exception($"無法刪除資料列");

                result.Status = true;
                result.Message = $"操作成功";
                result.Data = metaData;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = $"操作失敗 : {ex.Message}";
                result.Data = metaData;
            }

            return result;
        }

        protected abstract TMetaData ToMetaData(TEntity entity);

        protected abstract TEntity ToEntity(TMetaData metaData);
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using XinRevolution.Entity.Entities;
using XinRevolution.Manager.MetaData;
using XinRevolution.Manager.Models;
using XinRevolution.Repository.Interfaces;

namespace XinRevolution.Manager.Services
{
    public class UserService
    {
        private readonly IUnitOfWork<DbContext> _unitOfWork;

        public UserService(IUnitOfWork<DbContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public OperationResult<UserEntity> Login(UserMD data)
        {
            var result = new OperationResult<UserEntity>();

            try
            {
                var entity = _unitOfWork.GetRepository<UserEntity>().Single(x => x.Account.Equals(data.Account, StringComparison.CurrentCultureIgnoreCase));

                if (entity == default(UserEntity))
                    throw new Exception($"帳號錯誤");

                if (!entity.Password.Equals(data.Password, StringComparison.CurrentCultureIgnoreCase))
                    throw new Exception($"密碼錯誤");

                result.Status = true;
                result.Message = $"操作成功";
                result.Data = entity;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = $"操作失敗 - {ex.Message}";
                result.Data = null;
            }

            return result;
        }

        public OperationResult<UserMD> FindMetaData(int id = -1)
        {
            var result = new OperationResult<UserMD>();

            try
            {
                var entity = id == -1? new UserEntity() : _unitOfWork.GetRepository<UserEntity>().Single(x => x.Id == id);

                if (entity == default(UserEntity))
                    throw new Exception($"無法取得使用者資料");

                result.Status = true;
                result.Message = $"操作成功";
                result.Data = ToMetaData(entity);
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = $"操作失敗 - {ex.Message}";
                result.Data = null;
            }

            return result;
        }

        public OperationResult<List<UserEntity>> FindAll()
        {
            var result = new OperationResult<List<UserEntity>>();

            try
            {
                var entities = _unitOfWork.GetRepository<UserEntity>().Find().ToList();

                result.Status = true;
                result.Message = $"操作成功";
                result.Data = entities;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = $"操作失敗 - {ex.Message}";
                result.Data = null;
            }

            return result;
        }

        public OperationResult<UserMD> Create(UserMD data)
        {
            var result = new OperationResult<UserMD>();

            try
            {
                _unitOfWork.GetRepository<UserEntity>().Add(ToEntity(data));

                if (_unitOfWork.Commit() <= 0)
                    throw new Exception($"無法新增資料列");

                result.Status = true;
                result.Message = $"操作成功";
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = $"操作失敗 - {ex.Message}";
                result.Data = data;
            }

            return result;
        }

        public OperationResult<UserMD> Update(UserMD data)
        {
            var result = new OperationResult<UserMD>();

            try
            {
                _unitOfWork.GetRepository<UserEntity>().Update(ToEntity(data));

                if (_unitOfWork.Commit() <= 0)
                    throw new Exception($"無法更新資料列");

                result.Status = true;
                result.Message = $"操作成功";
                result.Data = data;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = $"操作失敗 - {ex.Message}";
                result.Data = data;
            }

            return result;
        }

        public OperationResult<UserMD> Delete(UserMD data)
        {
            var result = new OperationResult<UserMD>();

            try
            {
                _unitOfWork.GetRepository<UserEntity>().Delete(ToEntity(data));

                if (_unitOfWork.Commit() <= 0)
                    throw new Exception($"無法刪除資料列");

                result.Status = true;
                result.Message = $"操作成功";
                result.Data = data;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = $"操作失敗 - {ex.Message}";
                result.Data = data;
            }

            return result;
        }

        private UserMD ToMetaData(UserEntity data)
        {
            if (data == null)
                return null;

            return new UserMD
            {
                Id = data.Id,
                Account = data.Account,
                Password = data.Password,
                Name = data.Name,
                Phone = data.Phone,
                Address = data.Address,
                Mail = data.Mail
            };
        }

        private UserEntity ToEntity(UserMD data)
        {
            if (data == null)
                return null;

            return new UserEntity
            {
                Id = data.Id,
                Account = data.Account,
                Password = data.Password,
                Name = data.Name,
                Phone = data.Phone,
                Address = data.Address,
                Mail = data.Mail
            };
        }
    }
}

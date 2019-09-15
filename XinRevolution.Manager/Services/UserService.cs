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
            var user = _unitOfWork.GetRepository<UserEntity>().Single(x => x.Account.Equals(data.Account, StringComparison.CurrentCultureIgnoreCase));

            if (user == default(UserEntity))
            {
                result.Status = false;
                result.Message = $"帳號錯誤";

                return result;
            }

            if (!user.Password.Equals(data.Password, StringComparison.CurrentCultureIgnoreCase))
            {
                result.Status = false;
                result.Message = $"密碼錯誤";

                return result;
            }

            result.Status = true;
            result.Message = $"登入成功";
            result.Data = user;

            return result;
        }

        public UserMD FindMetaData(int id)
        {
            var result = ToMetaData(_unitOfWork.GetRepository<UserEntity>().Single(x => x.Id == id));

            return result;
        }

        public List<UserEntity> FindAll()
        {
            var result = _unitOfWork.GetRepository<UserEntity>().Find().ToList();

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
            catch(Exception ex)
            {
                result.Status = false;
                result.Message = $"操作失敗 ({ex.Message})";
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
            }
            catch(Exception ex)
            {
                result.Status = false;
                result.Message = $"操作失敗 ({ex.Message})";
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
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = $"操作失敗 ({ex.Message})";
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

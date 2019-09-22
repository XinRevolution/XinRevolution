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
    public class UserService : BaseService<UserEntity, UserMD>
    {
        public UserService(IUnitOfWork<DbContext> unitOfWork) : base(unitOfWork)
        {

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
                result.Message = $"操作失敗 : {ex.Message}";
                result.Data = null;
            }

            return result;
        }
        
        protected override UserMD ToMetaData(UserEntity entity)
        {
            return new UserMD
            {
                Id = entity.Id,
                Account = entity.Account,
                Password = entity.Password,
                Name = entity.Name,
                Phone = entity.Phone,
                Address = entity.Address,
                Mail = entity.Mail
            };
        }

        protected override UserEntity ToEntity(UserMD metaData)
        {
            return new UserEntity
            {
                Id = metaData.Id,
                Account = metaData.Account,
                Password = metaData.Password,
                Name = metaData.Name,
                Phone = metaData.Phone,
                Address = metaData.Address,
                Mail = metaData.Mail
            };
        }
    }
}

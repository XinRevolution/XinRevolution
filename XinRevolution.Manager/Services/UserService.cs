using Microsoft.EntityFrameworkCore;
using System;
using XinRevolution.Entity.Entities;
using XinRevolution.Manager.MetaData;
using XinRevolution.Manager.Models;
using XinRevolution.Repository;
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
    }
}

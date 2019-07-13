using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XinRevolution.Entity.Model;
using XinRevolution.Repository.Interface;
using XinRevolution.Web.Models.MetaData.Management;
using XinRevolution.Web.Models.ViewModel.Management;

namespace XinRevolution.Web.Services.Management
{
    public class UserMnagementService
    {
        private IUserRepository _repository;

        public UserMnagementService(IUserRepository repository)
        {
            _repository = repository;
        }

        public Result<UserModel> Login(string account, string password)
        {
            var result = new Result<UserModel>();

            try
            {
                var user = _repository.FindByKey(account);

                if (user == default(UserModel))
                    throw new Exception("帳號錯誤");

                if (!user.Password.Equals(password, StringComparison.CurrentCultureIgnoreCase))
                    throw new Exception("密碼錯誤");

                result.Status = true;
                result.Message = "登入成功";
                result.Data = user;
            }
            catch(Exception ex)
            {
                result.Status = false;
                result.Message = $"登入失敗 : {ex.Message}";
            }

            return result;
        }

        private UserMD ToMetaData(UserModel model)
        {
            return new UserMD
            {
                Id = model.Id,
                Account = model.Account,
                Password = model.Password,
                Name = model.Name,
                Phone = model.Phone,
                EMail = model.EMail,
                Address = model.Address
            };
        }

        private UserModel ToModel(UserMD metaData)
        {
            return new UserModel
            {
                Id = metaData.Id,
                Account = metaData.Account,
                Password = metaData.Password,
                Name = metaData.Name,
                Phone = metaData.Phone,
                EMail = metaData.EMail,
                Address = metaData.Address
            };
        }
    }
}

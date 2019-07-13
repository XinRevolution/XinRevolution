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

        public Result<UserModel> Login(UserMD data)
        {
            var result = new Result<UserModel>();

            try
            {
                var user = _repository.FindByKey(data.Account);

                if (user == default(UserModel))
                    throw new Exception("帳號錯誤");

                if (!user.Password.Equals(data.Password, StringComparison.CurrentCultureIgnoreCase))
                    throw new Exception("密碼錯誤");

                result.Status = true;
                result.Message = "登入成功";
                result.Data = user;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = $"登入失敗 : {ex.Message}";
            }

            return result;
        }

        public IEnumerable<UserModel> Find()
        {
            var result = _repository.FindAll();

            return result;
        }

        public UserMD FindMetaData(long id = -1)
        {
            var result = id == -1 ? new UserMD() : ToMetaData(_repository.FindById(id));

            return result;
        }

        public Result<UserMD> Create(UserMD data)
        {
            var result = new Result<UserMD>();

            try
            {
                result.Status = _repository.Create(ToModel(data));
                result.Message = "新增成功";
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = $"新增失敗 : {ex.Message}";
                result.Data = data;
            }

            return result;
        }

        public Result<UserMD> Update(UserMD data)
        {
            var result = new Result<UserMD>();

            try
            {
                result.Status = _repository.Update(ToModel(data));
                result.Message = "更新成功";
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = $"更新失敗 : {ex.Message}";
                result.Data = data;
            }

            return result;
        }

        public Result<UserMD> Delete(UserMD data)
        {
            var result = new Result<UserMD>();

            try
            {
                result.Status = _repository.Delete(ToModel(data));
                result.Message = "刪除成功";
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = $"刪除失敗 : {ex.Message}";
                result.Data = data;
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

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
        private IUserRepository<UserModel> _repository;

        public UserMnagementService(IUserRepository<UserModel> repository)
        {
            _repository = repository;
        }

        public List<UserModel> Find()
        {
            return _repository.FindAll().ToList();
        }

        public UserMD FindMD(long id = 0)
        {
            var data = _repository.FindByID(id);

            return data == default(UserModel) ? new UserMD() : FromModel(data);
        }

        public Result<UserModel> Create(UserMD metaData)
        {
            Result<UserModel> result = new Result<UserModel>();

            try
            {
                result.Data = _repository.Create()
            }
            catch(Exception ex)
            {
                result.Status = false;
                result.Message = ex.Message;
                result.Data = null;
            }

            return result;
        }

        public bool Update(UserMD metaData)
        {
            return _repository.Update(ToModel(metaData));
        }

        public bool Delete(UserMD metaData)
        {
            return _repository.Delete(metaData.Id);
        }

        private UserMD FromModel(UserModel model)
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

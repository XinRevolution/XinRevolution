using System;
using System.Collections.Generic;
using System.Text;
using XinRevolution.Entity.Model;

namespace XinRevolution.Repository.Interface
{
    public interface IUserRepository : IBaseRepository<UserModel>
    {
        UserModel FindByKey(string key);
    }
}

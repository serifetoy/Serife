using Serife.Common.DTOs;
using Serife.Common.Result;
using Serife.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serife.Business.Abstract
{
    public interface IUserService : IBaseService<UserDTO>
    {
        BCResponse GetUsers();
        BCResponse GetById(int userId);
        BCResponse GetByUserName(string userName);
    }
}

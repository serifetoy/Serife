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
    public interface IGroupService : IBaseService<GroupDTO>
    {
        //BCResponse GetList(int userId);
        BCResponse GetById(int userId);
        
        

    }
}

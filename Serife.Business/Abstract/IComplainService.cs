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
    public interface IComplainService : IBaseService <ComplainDTO>
    {  
        // BCResponse GetAll(Expression<Func>Complain, bool>>filter=null);
        BCResponse GetById(int userId);
        BCResponse GetListAll();
        BCResponse GetComplainByUserId(int userId);
    }
}

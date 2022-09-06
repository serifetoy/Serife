using Serife.Common.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serife.Business.Abstract
{
    public interface IBaseService<DTO> where DTO : class
    {
        BCResponse Add(DTO dto);
        BCResponse Update(DTO dto);
        BCResponse Delete(int userId);
    }
}

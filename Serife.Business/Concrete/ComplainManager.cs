using Serife.Business.Abstract;
using Serife.Common.DTOs;
using Serife.Common.Result;
using Serife.DataLayer;
using Serife.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serife.Business.Concrete
{
   
        public class ComplainManager : IComplainService
        {

            DalComplain _dalComplain;

            public ComplainManager(DalComplain dalComplain)
            {
                _dalComplain = dalComplain;
            }

            public BCResponse Add(ComplainDTO dto)
            {
                throw new NotImplementedException();
            }

            public BCResponse Delete(int id)
            {
                throw new NotImplementedException();
            }
        public BCResponse Update(ComplainDTO dto)
        {
            throw new NotImplementedException();
        }

        public BCResponse GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Complain> GetComplainByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public BCResponse Update(Complain complain)
        {
            throw new NotImplementedException();
        }//burda hata var BAK
    }

}


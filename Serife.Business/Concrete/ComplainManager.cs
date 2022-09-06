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

        ChatAppContext chatAppContext = new ChatAppContext();

        public BCResponse Add(ComplainDTO dto)
        {
            throw new NotImplementedException();
        }

        public BCResponse Delete(int id)
        {
            throw new NotImplementedException();
        }

        public BCResponse GetById(int complainId)
        {
            var result = _dalComplain.GetById(complainId);

            if (result != null)
            {
                return new BCResponse() { Value = result };
            }

            return new BCResponse() { Errors = "Kullanıcı Bulunamadı" };      

        }
        public BCResponse GetListAll()
        {
            var result = _dalComplain.GetListAll();
            if (result.Count > 0)
            {
                return new BCResponse() { Value = result };
            }
            return new BCResponse() { Errors = "Kayıt Bulunamadı" };
        }//burayı düzenle,liste dönmesi lazım

        public BCResponse Update(ComplainDTO dto)
        {
            throw new NotImplementedException();
        }

        public BCResponse GetComplainByUserId(int userId) //burayı düzenle
        {
            var result = _dalComplain.GetComplainByUserID(userId);

            if (result != null)
            {
                return new BCResponse() { Value = result };
            }

            return new BCResponse() { Errors = "Kullanıcı Bulunamadı" };
        }

    }

}


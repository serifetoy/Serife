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

        public List<Complain> GetComplainByUserID(int id)
        {
            return chatAppContext.Set<Complain>().
                    Where(x => x.ComplainedOfUserId == id).
                    ToList();
        }

        public List<Complain> GetListAll()
        {
            return chatAppContext.Set<Complain>().ToList();
        }

        public BCResponse Update(ComplainDTO dto)
        {
            throw new NotImplementedException();
        }

        public BCResponse Update(Complain complain)
        {
            throw new NotImplementedException();
        }//burda bende hata var ben yanlış bişi eklemiştim sonra düzelticem

        public List<Complain> GetComplainByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        
    }

}


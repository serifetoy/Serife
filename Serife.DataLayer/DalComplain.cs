using Microsoft.EntityFrameworkCore;
using Serife.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Serife.DataLayer
{
    public class DalComplain:DalBase<Complain>
    {
        ChatAppContext chatAppContext = new ChatAppContext();

        //public List<Complain> GetListAll()
        //{
        //    return chatAppContext.Set<Complain>().ToList();
        //}
       
        public Complain? GetById(int id)
        {
            var values = chatAppContext.Set<Complain>().Find(id);
            if (values != null)
            {
                return values;
            }
            return null;
        }

        public List<Complain> GetComplainByUserID(int id)
        {
            return chatAppContext.Set<Complain>().Where(x => x.ComplainantUserId == id).ToList();
        }

        public List<Complain> GetListAll()
        {
            return chatAppContext.Set<Complain>().ToList();

        }

    }
}

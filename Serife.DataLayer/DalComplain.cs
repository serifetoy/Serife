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
    public class DalComplain : DalBase<Complain>
    {
        ChatAppContext chatAppContext = new ChatAppContext();


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
            
            return chatAppContext.Set<Complain>().
                    Where(x => x.ComplainedOfUserId == id).
                    ToList();


        }
        public List<Complain> GetListAll()
        {
            return chatAppContext.Set<Complain>().ToList();

        }

        public bool Any(int? complainId = null, int? complainantUserId = null, int? complainedOfUserId = null, int? complainStatusId = null)
        {

            return chatAppContext.Complains.
                Any(x =>
                            (!complainId.HasValue || x.ComplainId == complainId) &&
                            (!complainedOfUserId.HasValue || x.ComplainedOfUserId == complainedOfUserId) &&
                            (!complainantUserId.HasValue || x.ComplainantUserId == complainantUserId) &&
                            (!complainStatusId.HasValue || x.ComplainStatusId == complainStatusId));
            //  (string.IsNullOrEmpty(userName) || x.Username == userName)


        }

        public Complain? GetBy(int? complainId = null, int? complainantUserId = null, int? complainedOfUserId = null, int? complainStatusId = null)
        {

            return chatAppContext.Complains.
                Where(x =>
                            (!complainId.HasValue || x.ComplainId == complainId) &&
                            (!complainedOfUserId.HasValue || x.ComplainedOfUserId == complainedOfUserId) &&
                            (!complainantUserId.HasValue || x.ComplainantUserId == complainantUserId) &&
                            (!complainStatusId.HasValue || x.ComplainStatusId == complainStatusId)
                            ).FirstOrDefault();

        }

        public bool FindMessage(int? messageId = null)
        {

            return chatAppContext.Messages.
                Any(x =>
                            (!messageId.HasValue || x.MessageId == messageId));

        }

    }



    //public Complain? GetById(int id)
    //{
    //    var values = chatAppContext.Set<Complain>().Find(id);
    //    if (values != null)
    //    {
    //        return values;
    //    }
    //    return null;
    //}
}

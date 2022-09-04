using Serife.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serife.DataLayer
{
    public class DalFriend:DalBase<Friend>
    {
        ChatAppContext chatAppContext = new ChatAppContext();

        public List<Friend> GetList(int userID)
        {
            return chatAppContext.Set<Friend>().Where(x => x.RequestedUserId == userID).ToList();
        }
    }
}

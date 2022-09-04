using Serife.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serife.DataLayer
{

    public class DalMessage : DalBase<Message>
    {
        ChatAppContext chatAppContext = new ChatAppContext();
        public void SendMessage(Message message)
        {
            chatAppContext.Add(message);
            chatAppContext.SaveChanges();
        }

        public void Delete(Message message)
        {
            chatAppContext.Remove(message);
            chatAppContext.SaveChanges();
        }
        public List<Message> GetGroupMessage(int senderId, int groupId)
        {
            return chatAppContext.Set<Message>().Where(x => x.GroupId == groupId && x.SenderId == senderId).ToList();

        }
        public List<Message> GetPrivateMessage(int senderId, int groupId)
        {
            return chatAppContext.Set<Message>().Where(x => x.GroupId == groupId && x.SenderId == senderId).ToList();

        }
    }
}

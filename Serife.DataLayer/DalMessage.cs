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


        public List<Message> GetPrivateMessage(int senderId, int receiverId)
        {
            return chatAppContext.Set<Message>()
                                 .Where(m => m.SenderId == senderId && m.RecieverId == receiverId)
                                 .ToList();
        }

        public List<Message> GetGroupMessage(int senderId, int groupId)
        {
            return chatAppContext.Set<Message>()
                                 .Where(m => m.SenderId == senderId && m.GroupId == groupId)
                                 .ToList();
        }

        public Message SendMessage(Message message)
        {
            return message;
        }


        public bool Any(int? messageId = null, int? senderId = null, int? receiverId = null)
        {

            return chatAppContext.Messages.
                Any(x =>
                            (!messageId.HasValue || x.MessageId == messageId) &&
                            (!senderId.HasValue || x.SenderId == senderId) &&
                            (!receiverId.HasValue || x.RecieverId == receiverId));

            //(string.IsNullOrEmpty(userName) || x.Username == userName)


        }

        public Message? GetBy(int? messageId = null, int? senderId = null, int? receiverId = null, int? groupId = null)
        {

            return chatAppContext.Messages.
                Where(x =>
                            (!messageId.HasValue || x.MessageId == messageId) &&
                            (!senderId.HasValue || x.SenderId == senderId) &&
                            (!receiverId.HasValue || x.RecieverId == receiverId) &&
                            (!groupId.HasValue || x.GroupId == groupId)
                            
                            ).FirstOrDefault();

        }

        public int GetMember(int? userId = null, int? groupId = null)
        {

           var user =chatAppContext.GroupMembers.
                Where(x =>
                            (!userId.HasValue || x.UserId == userId)                       
                            ).FirstOrDefault();
           var group = chatAppContext.Messages.
               Where(x =>
                           (!groupId.HasValue || x.GroupId == groupId)
                           ).FirstOrDefault();

            if(user != null && group!=null)
            {
                return 1;
            }
            else
            {
                return 0;
            }

        }



        //public bool FindUser(int? senderId = null, int? receiverId = null)
        //{

        //    return chatAppContext.Messages.
        //        Any(x =>
        //                    (!senderId.HasValue || x.SenderId == senderId)&&
        //                    (!receiverId.HasValue || x.RecieverId == receiverId));

        //}

    }
}

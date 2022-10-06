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
        public bool Any(int? messageId = null, int? senderId = null, int? receiverId = null)
        {

            return chatAppContext.Messages.
                Any(x =>
                            (!messageId.HasValue || x.MessageId == messageId) &&
                            (!senderId.HasValue || x.SenderId == senderId) &&
                            (!receiverId.HasValue || x.RecieverId == receiverId));
          
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
      
        public GroupMember? getMember(int? userId, int? groupId)
        {
            return chatAppContext.GroupMembers
                .FirstOrDefault(c => c.UserId == userId && c.GroupId == groupId);
        }
        public Friend? GetFriend(int? senderId = null, int? receiverId = null)
        {
            return chatAppContext.
                Friends.
                FirstOrDefault(c => c.RequesterUserId == senderId && c.RequestedUserId == receiverId);


            //return chatAppContext.
            //    Friends.
            //    FirstOrDefault(c => c.RequesterUserId == receiverId && c.RequestedUserId == senderId);
        }

        public GroupMember? GetMember(int? userId, int? groupId)
        {
            return chatAppContext.GroupMembers.
            //.FirstOrDefault(c=>c.UserId==userId && c.GroupId==groupId);
            //FirstOrDefault(c => c.UserId == groupId && c.GroupId == userId);

            FirstOrDefault(
                    (c =>
                    (c.UserId == userId && c.GroupId == groupId) ||
                    (c.UserId == groupId && c.GroupId == userId)));

        }




    }
}

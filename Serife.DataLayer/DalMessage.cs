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


     

        //public int getMember(int? senderId = null, int? groupId = null)
        //{
        //    var sender = chatAppContext.Messages.
        //       Where(x =>
        //                   (!senderId.HasValue || x.SenderId == senderId)
        //                   ).FirstOrDefault();
            
        //    var group = chatAppContext.GroupMembers.
        //        Where(x =>
        //                    (!groupId.HasValue || x.GroupId == groupId)
        //                    ).FirstOrDefault();

            
            
        //    if (sender != null && group != null)
        //    {
        //        return 1;
        //    }
        //    else
        //    {
        //        return 0;
        //    }

        //}

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

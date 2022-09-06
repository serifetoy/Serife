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
                                 .Where(m => m.SenderId == senderId && m.ReceiverId == receiverId)
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


        public bool Any(int? messageId = null, int? senderId = null, int? receiverId = null, int? messageReferenceId = null)
        {

            return chatAppContext.Messages.
                Any(x =>
                            (!messageId.HasValue || x.MessageId == messageId) &&
                            (!senderId.HasValue || x.SenderId == senderId) &&
                            (!receiverId.HasValue || x.ReceiverId == receiverId) &&
                            (!messageReferenceId.HasValue || x.MessageReferenceId == messageReferenceId));

            //(string.IsNullOrEmpty(userName) || x.Username == userName)


        }

        public Message? GetBy(int? messageId = null, int? senderId = null, int? receiverId = null, int? groupId = null, int? messageReferenceId = null)
        {

            return chatAppContext.Messages.
                Where(x =>
                            (!messageId.HasValue || x.MessageId == messageId) &&
                            (!senderId.HasValue || x.SenderId == senderId) &&
                            (!receiverId.HasValue || x.ReceiverId == receiverId) &&
                            (!groupId.HasValue || x.GroupId == groupId) &&
                            (!messageReferenceId.HasValue || x.MessageReferenceId == messageReferenceId)
                            ).FirstOrDefault();

        }

    }
}

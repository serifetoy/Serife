using Serife.Common.DTOs;
using Serife.Common.Result;
using Serife.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serife.Business.Abstract
{
    public interface IMessageService : IBaseService<MessageDTO>
    {
        //List<Message> GetPrivateMessage(int senderId, int receiverId);
        //List<Message> GetGroupMessage(int senderId, int groupId);

        //Message SendMessage(Message message);

        BCResponse GetPrivateMessage(int senderId, int receiverId);
        BCResponse GetGroupMessage(int senderId, int groupId);

        BCResponse SendMessage(MessageDTO message);
    }
}

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
    public class MessageManager : IMessageService
    {
        ChatAppContext chatAppContext = new ChatAppContext();
        DalMessage _dalMessage;

        public MessageManager(DalMessage dalMessage)
        {
            _dalMessage = dalMessage;
        }

        public BCResponse Add(MessageDTO dto)
        {
            throw new NotImplementedException();
        }
        public BCResponse Update(MessageDTO dto)
        {
            throw new NotImplementedException();
        }

        public BCResponse Delete(int id)
        {
            #region Business
            if (id <= 0)
            {
                return new BCResponse() { Errors = "hatalı veri" };
            }
            #endregion
            #region Delete
            Message? entity = chatAppContext.Messages.
                               FirstOrDefault(u => u.MessageId == id);

            if (entity != null)
            {
                _dalMessage.Delete(entity);
                return new BCResponse() { Value = entity };

            }
            #endregion
            return new BCResponse() { Errors = "Mesaj silinemedi" };


        }

        List<Message> IMessageService.GetPrivateMessage(int senderId, int receiverId)
        {
            return chatAppContext.Set<Message>()
                                 .Where(m => m.SenderId == senderId && m.ReceiverId == receiverId)
                                 .ToList();
        }

        List<Message> IMessageService.GetGroupMessage(int senderId, int groupId)
        {
            return chatAppContext.Set<Message>()
                               .Where(m => m.SenderId == senderId && m.GroupId == groupId)
                               .ToList();
        }


       

       
    }
}

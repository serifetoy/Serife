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
           
                var message = _dalMessage.GetBy(messageId: id);
                if (message==null)
                {
                    return new BCResponse() { Errors = "Mesaj bulunamadı. " };
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

            public BCResponse GetGroupMessage(int UserId, int GroupId)
            {
                var isExistGroup = _dalMessage.GetMember(userId: UserId, groupId: GroupId);


                if (isExistGroup==1)
            {
                    return new BCResponse() { Value = isExistGroup };
                }
                return new BCResponse() { Errors = "Group Mesajı alınamadı" };
            }

            public BCResponse GetPrivateMessage(int SenderId, int ReceiverId)
            {
                var senderResult = _dalMessage.GetBy(senderId: SenderId);
                var receiverResult = _dalMessage.GetBy(receiverId: ReceiverId);


                if (senderResult != null && receiverResult != null)
                {
                    return new BCResponse() { Value = senderResult };
                }
                return new BCResponse() { Errors = "İki kişi arasında mesaj bulunamadı." };
            }
        
            public BCResponse SendMessage(MessageDTO message) // TEKRAR BAK! 
        {

            Message newMessage = new Message();
            #region Business

            if (message.GroupId==0)
            {
                var isFriend = _dalMessage.GetBy(senderId: message.SenderId, receiverId: message.RecieverId);
                if (isFriend==null)
                {
                    return new BCResponse() { Errors = "Arkadaş olunmayan kişiye mesaj gönderilemez." };
                }

                newMessage.SenderId = message.SenderId;
                newMessage.RecieverId = message.RecieverId;
                newMessage.MessageContent = message.MessageContent;
                newMessage.SendDate = message.SendDate;
            }
            else if (message.RecieverId==0)
            {
                var isGroup = _dalMessage.GetBy(senderId: message.SenderId, groupId: message.GroupId);
                if (isGroup == null)
                {
                    return new BCResponse() { Errors = "Grupta olmayan kullanıcı gruba mesaj gönderemez" };
                }
                newMessage.SenderId = message.SenderId;
                newMessage.GroupId = message.GroupId;
                newMessage.MessageContent = message.MessageContent;
                newMessage.SendDate = message.SendDate;

            }
            else
            {
                return new BCResponse() { Errors = "Mesaj aynı anda gruba ve kişiye gönderilemez." };

            }

            #endregion


            var result = _dalMessage.SendMessage(newMessage);
            if (result != null)
            {
                return new BCResponse() { Value = result };
            }

            return new BCResponse() { Errors = "Sistem Hatası" };
        }

        
        
    
        
    }
    }


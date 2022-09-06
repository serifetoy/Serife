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

            public BCResponse GetGroupMessage(int SenderId, int GroupId)
            {
                var groupResult = _dalMessage.GetBy(groupId: GroupId);
                var senderResult = _dalMessage.GetBy(senderId: SenderId);


                if (groupResult != null && senderResult != null)
                {
                    return new BCResponse() { Value = senderResult };
                }
                return new BCResponse() { Errors = "Group Mesajı alınamadı" };
            }

            public BCResponse GetPrivateMessage(int SenderId, int ReceiverId)
            {
                var senderResult = _dalMessage.GetBy(senderId: SenderId);
                var receiverResult = _dalMessage.GetBy(receiverId: ReceiverId);


                if ((senderResult != null && receiverResult == null) || (senderResult != null && receiverResult != null))
                {
                    return new BCResponse() { Value = senderResult };
                }
                return new BCResponse() { Errors = "Gizli Mesaj alınamadı" };
            }


            public BCResponse SendMessage(Message message)//burayı düzenle
            {

            throw new NotImplementedException();



        }
        }
    }


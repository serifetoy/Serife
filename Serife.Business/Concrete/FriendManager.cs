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
    public class FriendManager : IFriendService
    {
        ChatAppContext chatAppContext = new ChatAppContext();
        DalFriend _dalFriend;

        public FriendManager(DalFriend dalFriend)
        {
            _dalFriend = dalFriend;
        }

        public BCResponse Add(FriendDTO dto)
        {
            #region Business
            var isExists = _dalFriend.Any(friendId: dto.FriendId);
            if (isExists)
            {
                return new BCResponse() { Errors = "Kisi ile zaten arkadassınız." };

            }

            #endregion
            #region Map To Entity
            Friend entity = new Friend();
            entity.FriendId = dto.FriendId;
            entity.RequesterUserId = dto.RequesterUserId;
            entity.RequestedUserId = dto.RequestedUserId;
            entity.FriendStatusId = dto.FriendStatusId;
            entity.RequestedDate = dto.RequestedDate;

            #endregion

            #region Update
            var result = _dalFriend.Add(entity);
            if (result > 0)
            {

                return new BCResponse() { Value = result };

            }
            #endregion
            return new BCResponse() { Errors = "Sistem Hatası" };
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
            Friend? entity = chatAppContext.Friends.FirstOrDefault(u => u.FriendId == id);


            if (entity != null)
            {
                _dalFriend.Delete(entity);
                return new BCResponse() { Value = entity };

            }


            #endregion
            return new BCResponse() { Errors = "Kullanıcı silinemedi" };
        }

        public BCResponse Update(FriendDTO dto)
        {

            #region Business
            if (dto.FriendId <= 0)
            {
                return new BCResponse() { Errors = "hatalı veri" };
            }
            #endregion


            #region Map To Entity
            Friend? entity = _dalFriend.GetBy(friendId: dto.FriendId);
            if (entity == null)
            {
                return new BCResponse() { Errors = "arkadaş bulunamadı" };
            }

            entity.FriendId = dto.FriendId;
            entity.RequesterUserId = dto.RequesterUserId;
            entity.RequestedUserId = dto.RequestedUserId;
            entity.FriendStatusId = dto.FriendStatusId;
            entity.RequestedDate = dto.RequestedDate;

            #endregion


            #region Update
            var result = _dalFriend.Update(entity);
            if (result > 0)
            {
                return new BCResponse() { Value = result };

            }
            #endregion
            return new BCResponse() { Errors = "Sistem Hatası" };

        }

        public BCResponse GetList(int id)
        {
            var result =_dalFriend.GetList(id);
            if (result.Count>0)
            {
                return new BCResponse() { Value = result };
            }
            return new BCResponse() { Errors = "Kayıt Bulunamadı" };
        }


    }
}

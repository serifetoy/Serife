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
    public class GroupMemberManager : IGroupMemberService
    {
        ChatAppContext chatAppContext = new ChatAppContext();
        DalGroupMember _dalGroupMember;

     

        public GroupMemberManager(DalGroupMember dalGroupMember)
        {
            _dalGroupMember = dalGroupMember;
        }

        public BCResponse Add(GroupMemberDTO dto)
        {
            #region Business
            var isExists = _dalGroupMember.Any(groupMemberId: dto.GroupMemberId);
            if (isExists)
            {
                return new BCResponse() { Errors = "Kişi grupta var olmaktadır." };

            }

            #endregion

            #region Map To Entity
            GroupMember entity = new GroupMember();
            entity.GroupMemberId = dto.GroupMemberId;
            entity.GroupId = dto.GroupId;
            entity.UserId = dto.UserId;
            entity.AddedUserId = dto.AddedUserId;
            entity.AddedDate = dto.AddedDate;
            entity.IsAdmin = dto.IsAdmin;
            #endregion

            #region Insert
            if (entity.AddedUserId < 0)
            {
                var result = _dalGroupMember.Add(entity);
                if (result > 0)
                {
                    return new BCResponse() { Value = result };
                }

                return new BCResponse() { Errors = "Sistem Hatası" };
            }

            return new BCResponse() { Errors = "Gereklilikler sağlanamadı" };

            #endregion

           // var userExists = _dalGroupMember.Any(userId: dto.UserId);
           // var groupExists = _dalGroupMember.Any(groupId: dto.GroupId);
           //// var groupPhotoExists = _dalGroup.Any(groupPhotoId: dto.GroupProfilePhoto);
           


           // if ((userExists&&groupExists)&& dto.IsAdmin==true)
           // {
           //     return new BCResponse() { Value = "adminsin kişi ekleyebilir ve grup resmini değiştirebilirsin" };

           //     //kişi ekleyebilir ve grup resmini değiştirebilir.
           // }
           // return new BCResponse() { Errors = "Böyle bir yetkiniz bulunmamaktadır" };
        }//admin olma kısmı burada

        public BCResponse Delete(int id)
        {
            #region Business
            if (id <= 0)
            {
                return new BCResponse() { Errors = "hatalı veri" };
            }
            #endregion
            #region Delete
            GroupMember? entity = chatAppContext.GroupMembers.FirstOrDefault(u => u.GroupMemberId == id);
            if (entity != null)
            {
                _dalGroupMember.Delete(entity);
                return new BCResponse() { Value = entity };

            }
            #endregion
            return new BCResponse() { Errors = "Grup Üyesi silinemedi" };
        }

        public BCResponse Update(GroupMemberDTO dto)//YAZILACAK
        {
            throw new NotImplementedException();

        }

        public BCResponse GetById(int id)
        {
            var result = _dalGroupMember.GetById(id);
           
            if (result != null)
            {
                return new BCResponse() { Value = result };
            }
            return new BCResponse() { Errors = "Kayıt Bulunamadı" };

        }
    }
}

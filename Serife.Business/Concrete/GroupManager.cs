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
    public class GroupManager : IGroupService
    {
        ChatAppContext chatAppContext = new ChatAppContext();
        DalGroup _dalGroup;

        public GroupManager(DalGroup dalGroup)
        {
            _dalGroup = dalGroup;
        }

        public BCResponse Add(GroupDTO dto)
        {
            #region Business
            var isExists = _dalGroup.Any(idExcept: dto.GroupId);
            if (isExists)
            {
                return new BCResponse() { Errors = "Boyle bir grup bulunmaktadır" };

            }
            isExists = _dalGroup.Any(name: dto.Name);
            if (isExists)
            {
                return new BCResponse() { Errors = "Boyle bir grup ismi bulunmaktadır" };

            }

            #endregion

            #region Map To Entity
            Group entity = new Group();
            entity.Name = dto.Name;
            entity.Description = dto.Description;
            entity.GroupProfilePhoto = dto.GroupProfilePhoto;
            entity.CreaterUserId = dto.CreaterUserId;
            entity.CreateDate = dto.CreateDate;

            #endregion

            #region Insert
            if ((entity.Name.Length > 2 && entity.Name.Length < 25) && entity.Description.Length < 50)
            {
                var result = _dalGroup.Add(entity);
                if (result > 0)
                {
                    return new BCResponse() { Value = result };

                }
                return new BCResponse() { Errors = "Sistem Hatası" };

            }
            #endregion
            return new BCResponse() { Errors = "Gereklilikler sağlanamadı." };
        }

        public BCResponse Delete(int id)
        {
            #region Business
            if (id < 0)
            {
                return new BCResponse() { Errors = "Boyle bir grup bulunamadı" };

            }
            #endregion
            #region Delete
            Group? entity = chatAppContext.Groups.FirstOrDefault(g => g.GroupId == id);

            if (entity != null)
            {
                _dalGroup.Delete(entity);
                return new BCResponse() { Value = entity };

            }
            #endregion
            return new BCResponse() { Errors = "Group silinemedi" };
        }

        public BCResponse Update(GroupDTO dto)
        {
            #region Business
            if (dto.GroupId < 0)
            {
                return new BCResponse() { Errors = "Boyle bir grup bulunamadı" };

            }
            var isExists = _dalGroup.Any(idExcept: dto.GroupId, name: dto.Name);
            if (isExists)
            {
                return new BCResponse() { Errors = "Boyle bir grup ismi sistemde kayıtlıdır" };
            }
            #endregion
            #region Map To Entity
            Group? entity = _dalGroup.GetBy(id: dto.GroupId);
            if (entity == null)
            {
                return new BCResponse() { Errors = "Group bulunamadı" };
            }
            entity.Name = dto.Name;
            entity.Description = dto.Description;
            entity.GroupProfilePhoto = dto.GroupProfilePhoto;
            entity.CreaterUserId = dto.CreaterUserId;
            entity.CreateDate = dto.CreateDate;
            #endregion

            #region Update
            var result = _dalGroup.Update(entity);
            if (result > 0)
            {
                return new BCResponse() { Value = result };

            }
            #endregion
            return new BCResponse() { Errors = "Sistem Hatası" };

        }

        public BCResponse GetBy(int userId)//BAKILMASI LAZIM 
        {
            var result = _dalGroup.GetBy(userId);

            if (result != null)
            {
                return new BCResponse() { Value = result };
            }

            return new BCResponse() { Errors = "Kullanıcı Bulunamadı" };
        }
        public BCResponse GetList(int userId)
        {
            var result = _dalGroup.GetList(userId);
            if (result.Count > 0)
            {
                return new BCResponse() { Value = result };
            }
            return new BCResponse() { Errors = "Kayıt Bulunamadı" };
        }

        BCResponse IGroupService.GetList(int id)
        {
            throw new NotImplementedException();
        }
    }
}

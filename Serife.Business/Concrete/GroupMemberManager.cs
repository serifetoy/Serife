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
            var isExists = _dalGroupMember.Any(addedUserId: dto.AddedUserId);
            if (isExists)
            {
                return new BCResponse() { Errors = "Kisi grupta zaten yer almaktadır." };
            }
            #endregion// bunu ekledim hata vermemesi için
            else
            {
                return null;//şimdilik null atadım, tekrar bak
            }

        }

        public BCResponse Delete(int id)
        {
            throw new NotImplementedException();
        }

        public BCResponse Update(GroupMemberDTO dto)
        {
            throw new NotImplementedException();
        }

        public List<GroupMember> GetListAll()
        {
            return chatAppContext.Set<GroupMember>().ToList();

        }
    }
}

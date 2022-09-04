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
        DalFriend _dalfriend;

        public FriendManager(DalFriend dalFriend)
        {
            _dalfriend = dalFriend;
        }
        public BCResponse Add(FriendDTO dto)
        {
            throw new NotImplementedException();
        }

        public BCResponse Delete(int id)
        {
            throw new NotImplementedException();
        }

        public BCResponse Update(FriendDTO dto)
        {
            throw new NotImplementedException();
        }

        public static object GetList(int userId)
        {
            throw new NotImplementedException();
        }
    }
}

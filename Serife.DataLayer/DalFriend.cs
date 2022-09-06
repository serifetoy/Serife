using Serife.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serife.DataLayer
{
    public class DalFriend : DalBase<Friend>
    {
        ChatAppContext chatAppContext = new ChatAppContext();
        public List<Friend> GetList(int id)
        {
            return chatAppContext.Set<Friend>()
                                 .Where(x => x.FriendId == id)
                                 .ToList();
        }


        public bool Any(int? friendId = null, int? requesterUserId = null, int? requestedUserId = null, byte? friendStatusId = null)
        {

            return chatAppContext.Friends.
                Any(x =>
                            (!friendId.HasValue || x.FriendId == friendId) &&
                            (!requesterUserId.HasValue || x.RequesterUserId == requesterUserId) &&
                            (!requestedUserId.HasValue || x.RequestedUserId == requestedUserId) &&
                            (!friendStatusId.HasValue || x.FriendStatusId == friendStatusId));

        }

        public Friend? GetBy(int? friendId = null, int? requesterUserId = null, int? requestedUserId = null, byte? friendStatusId = null)
        {

            return chatAppContext.Friends

                .Where(x =>
                            (!friendId.HasValue || x.FriendId == friendId) &&
                            (!requesterUserId.HasValue || x.RequesterUserId == requesterUserId) &&
                            (!requestedUserId.HasValue || x.RequestedUserId == requestedUserId)
                            ).FirstOrDefault();





        }

    }
}

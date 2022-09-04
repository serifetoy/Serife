using System;
using System.Collections.Generic;

namespace Serife.DataLayer.Entity
{
    public partial class Friend
    {
        public int FriendId { get; set; }
        public int RequesterUserId { get; set; }
        public DateTime RequestedDate { get; set; }
        public int RequestedUserId { get; set; }
        public byte FriendStatusId { get; set; }

        public virtual FriendStatus FriendStatus { get; set; } = null!;
        public virtual User RequestedUser { get; set; } = null!;
        public virtual User RequesterUser { get; set; } = null!;
    }
}

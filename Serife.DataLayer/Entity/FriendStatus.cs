using System;
using System.Collections.Generic;

namespace Serife.DataLayer.Entity
{
    public partial class FriendStatus
    {
        public FriendStatus()
        {
            Friends = new HashSet<Friend>();
        }

        public byte FriendStatusId { get; set; }
        public string Description { get; set; } = null!;

        public virtual ICollection<Friend> Friends { get; set; }
    }
}

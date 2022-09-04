using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serife.Common.DTOs;

namespace Serife.Common.DTOs
{
    public class FriendDTO
    {
        public int FriendId { get; set; }
        public int RequesterUserId { get; set; }
        public DateTime RequestedDate { get; set; }
        public int RequestedUserId { get; set; }
        public byte FriendStatusId { get; set; }

    }
}

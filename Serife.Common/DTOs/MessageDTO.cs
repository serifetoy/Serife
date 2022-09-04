using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serife.Common.DTOs
{
    public class MessageDTO
    {
        public int MessageId { get; set; }
        public int SenderId { get; set; }
        public int? RecieverId { get; set; }
        public int? GroupId { get; set; }
        public string MessageContent { get; set; } = null!;
        public DateTime SendDate { get; set; }
        public DateTime ReadDate { get; set; }

        
    }
}

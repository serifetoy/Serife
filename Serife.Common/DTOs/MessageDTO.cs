using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serife.Common.DTOs
{
    public class MessageDTO
    {
        public int MessageId { get; set; }
        [Required()]
        public int SenderId { get; set; }
        public int? RecieverId { get; set; } = null!;
        public int? GroupId { get; set; } = null!;
        [Required()]
        public string MessageContent { get; set; } = null!;
        [Required()]
        public DateTime SendDate { get; set; }
        public DateTime ReadDate { get; set; }

        
    }
}

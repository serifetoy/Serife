using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serife.Common.DTOs
{
    public class ComplainDTO
    {
        public int ComplainId { get; set; }
        public int ComplainantUserId { get; set; }
        public int ComplainedOfUserId { get; set; }
        public byte ComplainStatusId { get; set; }
        public DateTime ComplainDate { get; set; }
        public int MessageReferenceId { get; set; }

     
    }
}

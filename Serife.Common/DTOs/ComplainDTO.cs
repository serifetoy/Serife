using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serife.Common.DTOs
{
    public class ComplainDTO
    {      
        public int ComplainId { get; set; }
        [Required()]
        public int ComplainantUserId { get; set; }
        [Required()]
        public int ComplainedOfUserId { get; set; }
        [Required()]
        public byte ComplainStatusId { get; set; }
        [Required()]
        public DateTime ComplainDate { get; set; }
        [Required()]
        public int MessageReferenceId { get; set; }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serife.Common.DTOs
{
    public class GroupDTO
    {
        public int GroupId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? GroupProfilePhoto { get; set; }
        public int CreaterUserId { get; set; }
        public DateTime CreateDate { get; set; }

    
    }
}

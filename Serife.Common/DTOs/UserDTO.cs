using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serife.Common.DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }
        [Required()]
        public DateTime CreateDate { get; set; }
        [Required()]
        public string Name { get; set; } = null!;
        [Required()]
        public string Surname { get; set; } = null!;
        [Required()]
        public string Username { get; set; } = null!;
        [Required()]
        public string Email { get; set; } = null!;
        [Required()]
        public string Password { get; set; } = null!;
        
        public string? ProfilePhoto { get; set; }
        [Required()]
        public bool IsActive { get; set; }
        [Required()]
        public bool IsAdmin { get; set; }
        
    }
}

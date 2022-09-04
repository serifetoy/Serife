using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serife.Common.DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? ProfilePhoto { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }
    }
}

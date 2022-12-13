using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqary.DTO.Dtos.User
{
    public class UpdateUserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; } = string.Empty;
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string ImageString { get; set; } 
        public DateTime CreatedAt { get; set; }

    }
}

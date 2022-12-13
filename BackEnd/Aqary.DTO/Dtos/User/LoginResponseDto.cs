using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqary.DTO.Dtos.User
{
    public class LoginResponseDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string ImageString { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Token { get; set; }
    }
}

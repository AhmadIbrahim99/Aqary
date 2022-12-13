using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqary.DTO.Dtos.User
{
    public class ResponseUserTokenDto : ResponseUserDto
    {
        public string Token { get; set; }
    }
}

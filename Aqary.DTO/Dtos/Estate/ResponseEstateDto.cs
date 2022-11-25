using Aqary.Common.Extensions;
using Aqary.DataAccessLayer.Models;
using Aqary.DTO.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqary.DTO.Dtos
{
    public class ResponseEstateDto
    {
        public PagedResult<EstateDto> Estates { get; set; }
        public Dictionary<int, ResponseUserDto> Users{ get; set; }
    }
}

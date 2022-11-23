using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqary.DTO.Dtos.BaseEntity
{
    public class CreateEstateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int TypeEstate { get; set; }
        public bool Status { get; set; }
        public double Salary { get; set; }
        public double PriceInDinar { get; set; }
        public int IdUser { get; set; }
        public int IdCategory { get; set; }
    }
}

using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

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
        public virtual ICollection<string> AttachmentsString { get; set; }
        public int IdUser { get; set; }
        public int IdCategory { get; set; }
    }
}

using Aqary.DataAccessLayer.Models;
using Aqary.DTO.Dtos.User;
using System.Collections.Generic;

namespace Aqary.DTO.Dtos
{
    public class EstateDto
    {
        public EstateDto()
        {
            Attachments = new HashSet<Attachment>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TypeEstate { get; set; }
        public bool Status { get; set; }
        public double Salary { get; set; }
        public double PriceInDinar { get; set; }
        public int IdUser { get; set; }
        public int IdCategory { get; set; }

        public virtual Category IdCategoryNavigation { get; set; }
        public virtual ICollection<Attachment> Attachments { get; set; }
    }
}

using Aqary.DTO.Dtos.AttachmentDTO;
using System;
using System.Collections.Generic;

namespace Aqary.DTO.Dtos
{
    public class EstateDto
    {
        public EstateDto()
        {
            Attachments = new HashSet<AttachmentResponseDTO>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TypeEstate { get; set; }
        public bool Status { get; set; }
        public double Salary { get; set; }
        public double PriceInDinar { get; set; }
        public int IdUser { get; set; }
        public int IdCategory { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual CreateCategoryDto IdCategoryNavigation { get; set; }
        public virtual ICollection<AttachmentResponseDTO> Attachments { get; set; }
    }
}

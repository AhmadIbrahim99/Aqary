using System;
using System.Collections.Generic;

#nullable disable

namespace Aqary.DataAccessLayer.Models
{
    public partial class Estate
    {
        public Estate()
        {
            Attachments = new HashSet<Attachment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int TypeEstate { get; set; }
        public bool Status { get; set; }
        public double Salary { get; set; }
        public double PriceInDinar { get; set; }
        public int IdUser { get; set; }
        public int IdCategory { get; set; }

        public virtual Category IdCategoryNavigation { get; set; }
        public virtual ApplicationUser IdUserNavigation { get; set; }
        public virtual ICollection<Attachment> Attachments { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace Aqary.DataAccessLayer.Models
{
    public partial class Attachment
    {
        public int Id { get; set; }
        public string ImageString { get; set; }
        public int IdEstate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Estate IdEstateNavigation { get; set; }
    }
}

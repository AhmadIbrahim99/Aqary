using System;
using System.Collections.Generic;

#nullable disable

namespace Aqary.DataAccessLayer.Models
{
    public partial class Attachment : BaseEntity
    {
        public string ImageString { get; set; }
        public int IdEstate { get; set; }
        
        public virtual Estate IdEstateNavigation { get; set; }
    }
}

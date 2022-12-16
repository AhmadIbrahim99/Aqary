using System;
using System.Collections.Generic;

#nullable disable

namespace Aqary.DataAccessLayer.Models
{
    public partial class Category : BaseEntity
    {
        public Category()
        {
            Estates = new HashSet<Estate>();
        }

        public string Name { get; set; }

        public virtual ICollection<Estate> Estates { get; set; }
    }
}

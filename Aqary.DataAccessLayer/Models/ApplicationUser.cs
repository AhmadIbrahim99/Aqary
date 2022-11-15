using System;
using System.Collections.Generic;

#nullable disable

namespace Aqary.DataAccessLayer.Models
{
    public partial class ApplicationUser
    {
        public ApplicationUser()
        {
            Estates = new HashSet<Estate>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string ImageString { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Estate> Estates { get; set; }
    }
}

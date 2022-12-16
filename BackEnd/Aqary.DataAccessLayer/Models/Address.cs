using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqary.DataAccessLayer.Models
{
    public class Address : BaseEntity
    {
        public string FirstAddress { get; set; } = string.Empty;
        public string? SecoundAddress { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}

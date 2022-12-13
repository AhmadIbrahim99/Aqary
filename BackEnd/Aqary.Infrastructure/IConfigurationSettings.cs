using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqary.Infrastructure
{
    public interface IConfigurationSettings
    {
        string JwtKey { get; }

        string Issure { get; }

        //string WebSiteURl { get; }
    }
}

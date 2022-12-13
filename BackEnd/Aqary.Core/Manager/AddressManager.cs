using Aqary.Core.Manager.Interface;
using Aqary.DataAccessLayer.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqary.Core.Manager
{
    public class AddressManager : BaseManager<Address, Address, Address, Address>, IAddressManager
    {
        public AddressManager(AqaryDataBaseContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}

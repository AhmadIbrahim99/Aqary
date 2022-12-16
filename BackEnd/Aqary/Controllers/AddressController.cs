using Aqary.Core.Manager.Interface;
using Aqary.DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aqary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : BaseController<Address, Address, Address, Address>
    {
        public AddressController(IAddressManager manager) : base(manager)
        {
        }
    }
}

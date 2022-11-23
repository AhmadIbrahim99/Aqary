using Aqary.Core.Manager.Interface;
using Aqary.DataAccessLayer.Models;
using Aqary.DTO.Dtos.BaseEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aqary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateController : BaseController<Estate, CreateEstateDto, UpdateEstateDto, Estate>
    {
        public EstateController(IEstateManager manager)
            : base(manager)
        {
        }
    }

    
}

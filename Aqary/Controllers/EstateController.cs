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
        private readonly IEstateManager _manager;
        public EstateController(IEstateManager manager)
            : base(manager)
        {
            _manager = manager;
        }

        [HttpGet("sorting")]
        public IActionResult GetAll(int page = 1,
                                   int pageSize = 10,
                                   string searchText = "",
                                   string sortColumn = "",
                                   string sortDirection = "ascending") =>
           Ok(_manager.GetAllAsync(page, pageSize, searchText, sortColumn, sortDirection));

        [HttpGet("fileretrive/attachment")]
        public IActionResult Retrive(string fileName) =>
               File(_manager.Retrive(fileName), "image/jpeg", fileName);
    }


}

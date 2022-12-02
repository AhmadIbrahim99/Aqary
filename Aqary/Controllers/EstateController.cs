using Aqary.Core.Manager.Interface;
using Aqary.DataAccessLayer.Models;
using Aqary.DTO.Dtos.BaseEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        [HttpGet]
        public override async Task<IActionResult> Get()
               => Ok(await _manager.GetAllAsync(x=> x.Attachments));
        [HttpGet("GetById")]
        public override async Task<IActionResult> Get(int id)
               => Ok(await _manager.GetbyIdAsync(id, x => x.Attachments));

        [HttpGet("sorting")]
        public IActionResult GetAll(int page = 1,
                                   int pageSize = 10,
                                   string searchText = "",
                                   string sortColumn = "",
                                   string sortDirection = "ascending") =>
           Ok(_manager.GetAllFilterAsync(page, pageSize, searchText, sortColumn, sortDirection));

        [HttpGet("fileretrive/attachment")]
        public IActionResult Retrive(string fileName) =>
               File(_manager.Retrive(fileName), "image/jpeg", fileName);

        [HttpPost, Authorize]
        public override Task<IActionResult> Create(CreateEstateDto entity)
        {
            return base.Create(entity);
        }

        [HttpPut, Authorize]
        public override Task<IActionResult> Update(int id, UpdateEstateDto entity)
        {
            return base.Update(id, entity);
        }

        [HttpDelete, Authorize]
        public override Task<IActionResult> Delete(int id)
        {
            return base.Delete(id);
        }
    }


}

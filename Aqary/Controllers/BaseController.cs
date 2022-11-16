using Aqary.Controllers.Interface;
using Aqary.Core.Manager.Interface;
using Aqary.DataAccessLayer.Models.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Aqary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T,TCreateRequestDTO, TUpdateRequestDTO, TResponseDTO> : ControllerBase,
        IBaseController<T, TCreateRequestDTO, TUpdateRequestDTO, TResponseDTO>
         where T : class, IBaseEntity, new()
    {
        private readonly IBaseManager<T, TCreateRequestDTO, TUpdateRequestDTO, TResponseDTO> _manager;
        public BaseController(IBaseManager<T, TCreateRequestDTO, TUpdateRequestDTO, TResponseDTO> manager)
        {
            _manager = manager;
        }

        [HttpPost]
        public virtual async Task<IActionResult> Create(TCreateRequestDTO entity)
               => Ok(await _manager.CeateAsync(entity));

        [HttpDelete]
        public virtual async Task<IActionResult> Delete(int id)
        {
            await _manager.DeleteAsync(id);
            return Ok();
        }
        [HttpGet]
        public virtual async Task<IActionResult> Get()
               => Ok(await _manager.GetAllAsync());
        [HttpGet("GetById")]
        public virtual async Task<IActionResult> Get(int id)
               => Ok(await _manager.GetbyIdAsync(id));
        [HttpPut]
        public virtual async Task<IActionResult> Update(int id, TUpdateRequestDTO entity)
               => Ok(await _manager.UpdateAsync(id, entity));
    }
}

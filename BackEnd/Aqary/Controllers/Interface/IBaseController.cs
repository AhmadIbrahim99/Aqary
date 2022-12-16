using Aqary.DataAccessLayer.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Aqary.Controllers.Interface
{
    public interface IBaseController<T, TCreateRequestDTO, TUpdateRequestDTO, TResponseDTO>
     where T : class, IBaseEntity, new()
    {
        Task<IActionResult> Get();
        Task<IActionResult> Get(int id);
        Task<IActionResult> Delete(int id);
        Task<IActionResult> Update(int id, TUpdateRequestDTO entity);
        Task<IActionResult> Create(TCreateRequestDTO entity);
    }
}

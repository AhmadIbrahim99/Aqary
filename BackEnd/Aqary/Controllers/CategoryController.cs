using Aqary.Core.Manager.Interface;
using Aqary.DataAccessLayer.Models;
using Aqary.DTO.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aqary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController<Category, CreateCategoryDto, UpdateCategoryDto, Category>
    {
        public CategoryController(ICategoryManager manager) 
            : base(manager)
        {
        }

    }
}

using Aqary.Core.Manager.Interface;
using Aqary.DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aqary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController<Category, Category, Category, Category>
    {
        public CategoryController(ICategoryManager manager) 
            : base(manager)
        {
        }
    }
}

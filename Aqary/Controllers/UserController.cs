using Aqary.Core.Manager.Interface;
using Aqary.DataAccessLayer.Models;
using Aqary.DTO.Dtos.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aqary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController<ApplicationUser, CreateUserDto, UpdateUserDto, ApplicationUser>
    {
        public UserController(IUserManager manager)
            : base(manager)
        {
        }
    }
}

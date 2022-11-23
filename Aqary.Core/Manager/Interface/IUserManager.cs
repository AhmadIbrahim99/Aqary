using Aqary.DataAccessLayer.Models;
using Aqary.DTO.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqary.Core.Manager.Interface
{
    public interface IUserManager : IBaseManager<ApplicationUser, CreateUserDto, UpdateUserDto, ApplicationUser>
    {
    }
}

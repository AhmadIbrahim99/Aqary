using Aqary.Core.Manager.Interface;
using Aqary.DataAccessLayer.Models;
using Aqary.DTO.Dtos.User;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqary.Core.Manager
{
    public class UserManager :
        BaseManager<ApplicationUser, CreateUserDto, UpdateUserDto, ApplicationUser>
        , IUserManager
    {
        public UserManager(AqaryDataBaseContext context,
            IMapper mapper) : base(context, mapper)
        {
        }
        
    }
}

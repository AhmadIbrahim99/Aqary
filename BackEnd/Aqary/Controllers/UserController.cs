﻿using Aqary.Core.Manager.Interface;
using Aqary.DataAccessLayer.Models;
using Aqary.DTO.Dtos.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aqary.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : BaseController<ApplicationUser, CreateUserDto, UpdateUserDto, ResponseUserTokenDto>
    {
        private readonly IUserManager _userManager;
        public UserController(IUserManager manager)
            : base(manager)
        {
            _userManager = manager;
        }
        [HttpPost]
        [Route("Login")]
        public  IActionResult Login([FromBody] LoginDto dto)
        {
            var log = _userManager.Login(dto);
            return Ok(log);
        }

        [HttpGet("fileretrive/profilepic")]
        public IActionResult Retrive(string fileName) =>
            File(_userManager.Retrive(fileName), "image/jpeg", fileName);
    }
}

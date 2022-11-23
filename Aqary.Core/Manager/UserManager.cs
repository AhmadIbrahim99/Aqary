using Aqary.Core.Manager.Interface;
using Aqary.DataAccessLayer.Models;
using Aqary.DTO.Dtos.User;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Aqary.Core.Manager
{
    public class UserManager :
        BaseManager<ApplicationUser, CreateUserDto, UpdateUserDto, ApplicationUser>
        , IUserManager
    {
        private readonly AqaryDataBaseContext _context;
        private readonly IMapper _mapper;
        public UserManager(AqaryDataBaseContext context,
            IMapper mapper) : base(context, mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public override Task<ApplicationUser> CeateAsync(CreateUserDto entity)
        {
            if (_context.ApplicationUsers.Any(a => a.Email.ToLower().Equals(entity.Email.ToLower())))
                throw new InvalidOperationException("User Already Exist");
            if (entity.PasswordHash != entity.ConfirmPassword)
                throw new InvalidOperationException("Wrong Password");
            return base.CeateAsync(entity);
        }

        #region private

        private string HashPassword(string password)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            return hashedPassword;
        }

        private bool VerfyPassword(string password, string Hashedpassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, Hashedpassword);
        }
        private string GenerateJWTToken(ApplicationUser user)
        {

            var jwtKey = "#ahmad.key*&^vancy!@#$%^&*()_-+=-*/@@{}[]";
            var sercurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var credentials = new SigningCredentials(sercurityKey, SecurityAlgorithms.HmacSha256);

            var issure = "test.com";
            var claims = new[] {
            new Claim(JwtRegisteredClaimNames.Iss, issure),
            new Claim(JwtRegisteredClaimNames.Aud, issure),
            new Claim(JwtRegisteredClaimNames.Sub, $"{user.FirstName} {user.LastName}"),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim("Email", user.Email),
            new Claim("Id", user.Id.ToString()),
            new Claim("DateOfJoining", user.CreatedAt.ToString("yyyy-MM-dd")),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            //var token = new JwtSecurityToken(claims:
            //    claims, expires: DateTime.Now.AddDays(12),
            //    signingCredentials:credentials);

            return new JwtSecurityTokenHandler().
                WriteToken(new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddHours(2),
                    signingCredentials: credentials));
        }

        #endregion private




    }

}

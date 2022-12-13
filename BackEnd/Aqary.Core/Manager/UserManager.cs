using Aqary.Core.Manager.Interface;
using Aqary.DataAccessLayer.Models;
using Aqary.DTO.Dtos.User;
using AutoMapper;
using examBaraaDb.Common.Exceptions;
using examBaraaDb.Common.Helpers;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using InvalidOperationException = examBaraaDb.Common.Exceptions.InvalidOperationException;

namespace Aqary.Core.Manager
{
    public class UserManager :
        BaseManager<ApplicationUser, CreateUserDto, UpdateUserDto, ResponseUserTokenDto>
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



        public override async Task<ResponseUserTokenDto> CeateAsync(CreateUserDto entity)
        {
            if (_context.ApplicationUsers.Any(a => a.Email.ToLower().Equals(entity.Email.ToLower())))
            {
                throw new InvalidOperationException("User Already Exist");
            }

            if (entity.PasswordHash != entity.ConfirmPassword)
            {
                throw new InvalidOperationException("Wrong Password");
            }

            var url = "";

            if (!string.IsNullOrWhiteSpace(entity.ImageString))
            {
                url = Helper.SaveImage(entity.ImageString, "profileImages");
            }

            var hashPassword = HashPassword(entity.PasswordHash);
            entity.PasswordHash = hashPassword;
            var imag = "";
            if (!string.IsNullOrWhiteSpace(url))
            {
                var baseUrl = "https://localhost:44344";
                imag = $@"{baseUrl}/{url}";
                //imag = $@"{baseUrl}/api/v1/user/fileretrive/profilepic?filename={url}";
            }

            var result = await base.CeateAsync(entity);
            result.Image = imag;

            // var response = _mapper.Map<ResponseUserTokenDto>(result);
            result.Token = $"Bearer {GenerateJWTToken(result)}";

            return result;
        }
        public LoginResponseDto Login(LoginDto dto)
        {
            var user = _context.ApplicationUsers.FirstOrDefault(x => x.Email.ToLower().Equals(dto.Email.ToLower()));

            if (user == null || !VerifyHashPassword(dto.Password, user.PasswordHash))
            {
                throw new ServiceValidationException(300, "Invalid Email Or Password Received");
            }
            var res = _mapper.Map<LoginResponseDto>(user);

            res.Token = $"Bearer {GenerateJWTToken(user)}";

            return res;
        }
        public override async Task<ResponseUserTokenDto> UpdateAsync(int id, UpdateUserDto entity)
        {
            var url = "";

            if (!string.IsNullOrWhiteSpace(entity.ImageString))
            {
                url = Helper.SaveImage(entity.ImageString, "profileImages");
            }

            var hashPassword = HashPassword(entity.PasswordHash);
            entity.PasswordHash = hashPassword;

            if (!string.IsNullOrWhiteSpace(url))
            {
                var baseUrl = "https://localhost:44344";
                entity.ImageString = $@"{baseUrl}/{url}";
                //entity.ImageString = $@"{baseUrl}/api/v1/user/fileretrive/profilepic?filename={url}";
            }

            var result = await base.UpdateAsync(id, entity);

            return result;
        }
        public byte[] Retrive(string fileName)
        {
            var folderPath = Directory.GetCurrentDirectory();
            folderPath = $@"{folderPath}\{fileName}";
            var byteArray = File.ReadAllBytes(folderPath);
            return byteArray;
        }
        #region private

        private string HashPassword(string password)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            return hashedPassword;
        }

        private bool VerifyHashPassword(string password, string Hashedpassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, Hashedpassword);
        }
        private string GenerateJWTToken(ResponseUserDto user)
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

using AutoMapper;
using Aqary.DTO.Dtos.Category;
using Aqary.DataAccessLayer.Models;
using Aqary.DTO.Dtos.User;
using Aqary.DTO.Dtos.BaseEntity;

namespace Aqary.Core.Mapper
{
    public class Maping : Profile
    {
        public Maping()
        {

            CreateMap<Category, CreateCategoryDto>()
                .ReverseMap();

            CreateMap<ApplicationUser, CreateUserDto>()
                .ReverseMap().ForMember(x=>x.ImageString,c=>c.Ignore());

            CreateMap<ApplicationUser, ResponseUserTokenDto>()
                .ReverseMap();

            CreateMap<ApplicationUser, ResponseUserDto>()
                .ReverseMap();

            CreateMap<ResponseUserDto, ResponseUserTokenDto>()
                .ReverseMap();

            CreateMap<LoginDto, ApplicationUser>()
                .ReverseMap();

            CreateMap<LoginResponseDto, ApplicationUser>()
           .ReverseMap();

            CreateMap<LoginDto, LoginResponseDto>()
                .ReverseMap();

            CreateMap<UpdateUserDto, ApplicationUser>()
                .ReverseMap().ForMember(x=>x.ImageString,x=>x.Ignore());

            CreateMap<Estate, CreateEstateDto>()
                .ReverseMap();

        }
    }
}

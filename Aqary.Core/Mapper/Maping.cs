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
                .ReverseMap();
            CreateMap<ApplicationUser, ResponseUserTokenDto>()
                .ReverseMap();
            CreateMap<ApplicationUser, ResponseUserDto>()
                .ReverseMap();
            CreateMap<ResponseUserDto, ResponseUserTokenDto>()
                .ReverseMap();
            CreateMap<UpdateUserDto, ApplicationUser>()
                .ReverseMap();

            CreateMap<Estate, CreateEstateDto>()
                .ReverseMap();
        }
    }
}

using AutoMapper;
using Aqary.DataAccessLayer.Models;
using Aqary.DTO.Dtos.User;
using Aqary.DTO.Dtos.BaseEntity;
using Aqary.DTO.Dtos;
using Aqary.Common.Extensions;

namespace Aqary.Core.Mapper
{
    public class Maping : Profile
    {
        public Maping()
        {

            CreateMap<Category, CreateCategoryDto>()
                .ReverseMap();

            CreateMap<ApplicationUser, CreateUserDto>()
                .ForMember(x => x.ImageString, c => c.Ignore())
                .ReverseMap();

            CreateMap<ApplicationUser, ResponseUserTokenDto>()
                .ForMember(x => x.Image, c => c.MapFrom(e => e.ImageString))
                .ReverseMap();

            CreateMap<ApplicationUser, ResponseUserDto>()
                .ForMember(x=> x.Image, c=>c.MapFrom(e=> e.ImageString))
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
                .ForMember(x => x.ImageString, x => x.Ignore())
                .ReverseMap();

            CreateMap<Estate, CreateEstateDto>()
                .ReverseMap();

            CreateMap<EstateDto, Estate>()
                .ReverseMap();

            CreateMap<PagedResult<EstateDto>, PagedResult<Estate>>().ReverseMap();

        }
    }
}

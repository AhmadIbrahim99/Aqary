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
            CreateMap<Estate, CreateEstateDto>()
                .ReverseMap();
        }
    }
}

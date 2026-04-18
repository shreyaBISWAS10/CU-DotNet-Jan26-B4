using AutoMapper;
using NorthWindCatalog.Services.DTOs;
using NorthWindCatalog.Services.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NorthWindCatalog.Services.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>()
                .ForMember(dest => dest.ImageUrl,
                    opt => opt.MapFrom(src => "/images/" + src.CategoryId + ".jpeg"));

            CreateMap<Product, ProductDto>();
        }
    }

}

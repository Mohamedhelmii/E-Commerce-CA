using AutoMapper;
using E_Commerce.Core.DTOs;
using E_Commerce.Core.Entities.ProductAggregate;

namespace E_Commerce.APIs.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToRetyrnDTO>()
                .ForMember(PDTO => PDTO.Brand, p => p.MapFrom(pr => pr.Brand.Name));

            CreateMap<Product, ProductToRetyrnDTO>()
               .ForMember(PDTO => PDTO.Category, p => p.MapFrom(pr => pr.Category.Name));
        }
    }
}

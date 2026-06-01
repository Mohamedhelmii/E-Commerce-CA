using AutoMapper;
using E_Commerce.Core.DTOs;
using E_Commerce.Core.Entities.OrderAggregate;
using E_Commerce.Core.Entities.ProductAggregate;

namespace E_Commerce.APIs.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Address, AddressDTO>().ReverseMap();
            CreateMap<Product, ProductToRetyrnDTO>()
                .ForMember(PDTO => PDTO.Brand, p => p.MapFrom(pr => pr.Brand.Name))
               .ForMember(PDTO => PDTO.Category, p => p.MapFrom(pr => pr.Category.Name))
               //add ImageUrlResolver To Auto Mapper
               .ForMember(PDTO => PDTO.ImageUrl, p => p.MapFrom<ProductImageUrlSolver>());
            CreateMap<Order, OrderToReturnDTO>()
                .ForMember(ODTO => ODTO.DeliveryMethodName, o => o.MapFrom(d => d.DeliveryMethod.Name))
                .ForMember(ODTO => ODTO.ShippingPrice, o => o.MapFrom(a => a.DeliveryMethod.Price))
                .ForMember(ODTO => ODTO.ShipToAddress, o => o.MapFrom(a => a.ShipToAddress));
            CreateMap<OrderItem, OrderItemDTO>()
                .ForMember(OIDTO => OIDTO.ProductId, oi => oi.MapFrom(p => p.ProductItemOrdered.ProductId))
                .ForMember(OIDTO => OIDTO.ProductName, oi => oi.MapFrom(p => p.ProductItemOrdered.ProductName))
                .ForMember(OIDTO => OIDTO.imageUrl, oi => oi.MapFrom(p => p.ProductItemOrdered.ImageUrl));

            CreateMap<ProductBrand, BrandsToReturnDTO>();
            CreateMap<ProductCategory, CategoeiesToReturnDTO>();
            CreateMap<DeliveryMethod, DeliveryMethodDTO>();
        }
    }
}

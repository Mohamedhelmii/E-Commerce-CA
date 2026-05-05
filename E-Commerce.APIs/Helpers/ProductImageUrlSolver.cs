using AutoMapper;
using E_Commerce.Core.DTOs;
using E_Commerce.Core.Entities.ProductAggregate;

namespace E_Commerce.APIs.Helpers
{
    public class ProductImageUrlSolver : IValueResolver<Product, ProductToRetyrnDTO, string>
    {
        private readonly IConfiguration _config;
        public ProductImageUrlSolver(IConfiguration config)
        {
            _config = config;
        }
        public string Resolve(Product source, ProductToRetyrnDTO destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.ImageUrl)) return _config["ApiUrl"] + source.ImageUrl;

            return null;

        }
    }
}

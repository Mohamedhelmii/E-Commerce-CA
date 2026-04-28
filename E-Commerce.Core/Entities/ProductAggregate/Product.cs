using System;
namespace E_Commerce.Core.Entities.ProductAggregate
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;

        public Guid CategoryId { get; set; }
        public ProductCategory Category { get; set; } = null!;
        public Guid BrandId { get; set; }
        public ProductBrand Brand { get; set; } = null!;
    }
}

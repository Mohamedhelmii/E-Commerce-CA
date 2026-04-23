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
        public ProductCategory ProductCategory { get; set; } = null!;
        public Guid ProductId { get; set; }
        public ProductBrand ProductBrand { get; set; } = null!;
    }
}

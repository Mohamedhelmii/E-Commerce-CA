namespace E_Commerce.Core.Entities.ProductAggregate
{
    public class ProductCategory : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
            
        public ICollection<Product> Products { get; set; } = new HashSet<Product>();

    }
}

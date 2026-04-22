namespace E_Commerce.Core.Entities
{
    public class ProductBrand : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}

namespace E_Commerce.Core.Entities.OrderAggregate
{
    public class OrderItem : BaseEntity
    {
        /*
             I don't want to have a direct relationship between OrderItem and Product,
             because I want to keep the order history intact even if the product details change or the product is deleted.
             So instead of having a navigation property to Product,
             I will store the necessary product details (like name, picture URL, price) directly in the OrderItem entity at the time of order creation.
             This way, even if the product is updated or removed from the catalog later,
             the order history will still reflect the correct information about what was ordered.
        */
        public Guid ProductItemId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string PictureUrl { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Guid OrderId { get; set; }
        public Order Order { get; set; } = null!;
    }
}

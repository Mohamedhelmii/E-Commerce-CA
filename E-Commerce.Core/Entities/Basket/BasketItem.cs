namespace E_Commerce.Core.Entities.Basket
{
    public class BasketItem
    {
        public Guid productId { get; set; }
        public string productName { get; set; } = string.Empty;
        public string imageUrl { get; set; } = string.Empty;
        public decimal price { get; set; }
        public int quantity { get; set; }
        public string Brand { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
    }
}

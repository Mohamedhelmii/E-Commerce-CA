namespace E_Commerce.Core.DTOs
{
    public class OrderItemDTO
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public string imageUrl { get; set; } = null!;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}

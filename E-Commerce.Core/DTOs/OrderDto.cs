namespace E_Commerce.Core.DTOs
{
    public class OrderDto
    {
        public string BasketId { get; set; } = null!;
        public Guid DeliveryMethodId { get; set; }
        public AddressDTO ShippingAddress { get; set; } = null!;
    }
}

namespace E_Commerce.Core.Entities.OrderAggregate
{
    public class Order : BaseEntity
    {
        public Order() { }
        public Order(string buyerEmail, Address shipToAddress, DeliveryMethod deliveryMethod,
                     IReadOnlyList<OrderItem> orderItems, decimal subtotal)
        {
            BuyerEmail = buyerEmail;
            ShipToAddress = shipToAddress;
            DeliveryMethod = deliveryMethod;
            OrderItems = orderItems;
            Subtotal = subtotal;
        }
        public string BuyerEmail { get; set; } = string.Empty;
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.UtcNow;
        // The shipping address for the order, which includes details such as street, city, state, postal code, and country, used for delivering the order to the customer.
        public Address ShipToAddress { get; set; } = new Address();
        public Guid DeliveryMethodId { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; } = new DeliveryMethod();
        public IReadOnlyList<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public decimal Subtotal { get; set; }
        // The status of the order, which can be Pending, PaymentReceived, Shipped, etc., used to track the order's progress through the fulfillment process.
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        // This is the id returned by the payment provider (e.g., Stripe) after a successful payment, used for tracking and reference.
        public string PaymentIntentId { get; set; } = string.Empty;
        public decimal GetTotal() => Subtotal + DeliveryMethod.Price;

    }
}

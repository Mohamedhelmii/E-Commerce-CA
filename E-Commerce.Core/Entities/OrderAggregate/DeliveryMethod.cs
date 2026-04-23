using System;

namespace E_Commerce.Core.Entities.OrderAggregate
{
    public class DeliveryMethod : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string DeliveryTime { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}

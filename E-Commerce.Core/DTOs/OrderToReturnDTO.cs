using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.DTOs
{
    public class OrderToReturnDTO
    {
        public Guid Id { get; set; }
        public string BuyerEmail { get; set; } = null!;
        public DateTimeOffset OrderDate { get; set; }
        public AddressDTO ShipToAddress { get; set; } = null!;
        public string DeliveryMethodName { get; set; } = null!;
        public decimal ShippingPrice { get; set; }
        public IReadOnlyList<OrderItemDTO> OrderItems { get; set; } = null!;
        public double SubTotal { get; set; }
        public string Status { get; set; } = null!;
        public decimal Total { get; set; }
    }
}

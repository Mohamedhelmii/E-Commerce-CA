using E_Commerce.Core.Entities.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Interfaces
{
    public interface IOrderServices
    {
        public Task<Order?> CreateOrderAsync(string buyerEmail, string basketId, Guid deliveryMethodId, Address address);
        public Task<Order?> GetOrderForUserAsync(string buyerEmail);
        public Task<Order?> GetOrderByIdForUserAsync(Guid orderId, string buyerEmail);
        public Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync();
    }
}

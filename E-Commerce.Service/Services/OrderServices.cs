using E_Commerce.Core.Entities.OrderAggregate;
using E_Commerce.Core.Entities.ProductAggregate;
using E_Commerce.Core.Interfaces;
using E_Commerce.Core.Specification.OrderSpec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Service.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBasketRepo _redis;
        public OrderServices(IUnitOfWork unitOfWork, IBasketRepo redis)
        {
            _unitOfWork = unitOfWork;
            _redis = redis;
        }
        public async Task<Order?> CreateOrderAsync(string buyerEmail, string basketId, Guid deliveryMethodId, Address address)
        {
            var basket = await _redis.GetBasketAsync(basketId);
            if (basket == null) return null;
            var orderItems = new List<OrderItem>();
            foreach (var item in basket.basketItems)
            {
                var product = await _unitOfWork.GenericRepo<Product>().GetByIdAsync(item.productId);
                if(product != null)
                {
                    var productItemOrderd = new ProductItemOrdered(product.Id, product.Name, product.ImageUrl);
                    var orderItem = new OrderItem(productItemOrderd, product.Price, item.quantity);
                    orderItems.Add(orderItem);
                }
            }
            var deliveryMethod = await _unitOfWork.GenericRepo<DeliveryMethod>().GetByIdAsync(deliveryMethodId);
            var subTotal = orderItems.Sum(i => i.Price *  i.Quantity);
            var order = new Order(buyerEmail, address, deliveryMethod, orderItems, subTotal);
            _unitOfWork.GenericRepo<Order>().Add(order);
            var result = await _unitOfWork.SaveAsync();
            if(result <= 0) return null;
            return order;
        }

        public async Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync()
        {
            return await _unitOfWork.GenericRepo<DeliveryMethod>().GetAllAsync();
        }

        public async Task<Order?> GetOrderByIdForUserAsync(Guid orderId, string buyerEmail)
        {
            var spec = new OrderWithItemSpec(orderId, buyerEmail);
            return await _unitOfWork.GenericRepo<Order>().GetEntityWithSpecifcationAsync(spec);
        }

        public async Task<IReadOnlyList<Order?>> GetOrderForUserAsync(string buyerEmail)
        {
            var spec = new OrderWithItemSpec(buyerEmail);
            return await _unitOfWork.GenericRepo<Order>().GetAllWithSpecificationAsync(spec);
        }
    }
}

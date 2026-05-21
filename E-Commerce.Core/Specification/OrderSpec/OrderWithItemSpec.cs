using E_Commerce.Core.Entities.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Specification.OrderSpec
{
    public class OrderWithItemSpec : BaseSpecification<Order>
    {
        //to return history of orders
        public OrderWithItemSpec(string buyerEmail) : base(o => o.BuyerEmail == buyerEmail) 
        {
            AddInclude(o => o.OrderItems);
            AddInclude(o => o.DeliveryMethod);
            AddOrderByDescending(o => o.OrderDate);
        }

        //to return details of specific order
        public OrderWithItemSpec(Guid orderId, string buyerEmail)
            : base(o => o.Id == orderId && o.BuyerEmail == buyerEmail)
        {
            AddInclude(o => o.OrderItems);
            AddInclude(o => o.DeliveryMethod);
        }
    }
}

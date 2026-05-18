using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Entities.Basket
{
    public class CustomarBasket
    {
        // to use when deserialization
        public CustomarBasket() { }

        //to create basket if it didn't in one line
        public CustomarBasket(string id)
        {
            customarId = id;
        }
        public string customarId { get; set; } = string.Empty;
        public List<BasketItem> basketItems { get; set; } = new List<BasketItem>();
    }
}

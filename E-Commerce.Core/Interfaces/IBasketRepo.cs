using E_Commerce.Core.Entities.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Interfaces
{
    public interface IBasketRepo
    {
        Task<CustomarBasket?> GetBasketAsync(string basketId);
        Task<CustomarBasket?> AddorUpdateBasketAsync(CustomarBasket Basket);
        Task<bool> DeleteBasketAsync(string basketId);
    }
}

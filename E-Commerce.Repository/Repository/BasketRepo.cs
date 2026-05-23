using E_Commerce.Core.Entities.Basket;
using E_Commerce.Core.Interfaces;
using StackExchange.Redis;
using System;
using System.Text.Json;


namespace E_Commerce.Repository.Repository
{
    public class BasketRepo : IBasketRepo
    {
        private readonly IDatabase _database;
        public BasketRepo(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }
        public async Task<CustomarBasket?> AddorUpdateBasketAsync(CustomarBasket Basket)
        {
            //sreialize
            var jsonBasket = await _database.StringSetAsync(
                Basket.customarId,
                JsonSerializer.Serialize(Basket),
                TimeSpan.FromDays(30)
                );
            if(!jsonBasket) return null;

            return await GetBasketAsync(Basket.customarId);
        }

        public async Task<bool> DeleteBasketAsync(string basketId)
        {
            return await _database.KeyDeleteAsync(basketId);
        }

        public async Task<CustomarBasket?> GetBasketAsync(string basketId)
        {
            //Deserialize
            var data = await _database.StringGetAsync(basketId);
            return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomarBasket>(data);
        }
    }
}

using E_Commerce.Core.Entities.Basket;
using E_Commerce.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.APIs.Controllers
{
    public class BasketController : BaseApiController
    {
        private readonly IBasketRepo _basketRepo;

        public BasketController(IBasketRepo basketRepo)
        {
            _basketRepo = basketRepo;
        }
        [HttpGet]
        public async Task<ActionResult<CustomarBasket>> GetBasketById(string id)
        {
            var basket = await _basketRepo.GetBasketAsync(id);
            //if basket null or new user return new basket not error
            return Ok(basket ?? new CustomarBasket(id));
        }

        [HttpPost]
        public async Task<ActionResult<CustomarBasket>> AddOrUpdateBasket(CustomarBasket basket)
        {
            var updatedBasket = await _basketRepo.AddorUpdateBasketAsync(basket);
            if (updatedBasket == null) return BadRequest("Problem execution with basket");
            return Ok(updatedBasket);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteBasket(string id)
        {
            var deleted = await _basketRepo.DeleteBasketAsync(id);
            if (!deleted) return BadRequest("Problem deleting the basket");
            return Ok();
        }
    }
}

using E_Commerce.Core.Entities.ProductAggregate;
using E_Commerce.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IGenericRepo<Product> _ProductRepo;

        public ProductController(IGenericRepo<Product> ProductRepo)
        {
            _ProductRepo = ProductRepo;
        }

        [HttpGet]
        public async Task<ActionResult<Product>> GetProductById(Guid id)
        {
            var p = await _ProductRepo.GetByIdAsync(id);
            if(p == null) return NotFound();
            return Ok(p);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetAllProducts()
        {
            var p = await _ProductRepo.GetAllAsync();
            return Ok(p);
        }

    }
}

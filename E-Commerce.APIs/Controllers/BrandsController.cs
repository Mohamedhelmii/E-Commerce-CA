using E_Commerce.Core.Entities.ProductAggregate;
using E_Commerce.Core.Services;
using E_Commerce.Core.Specification.ProductSpec;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private IGenericRepo<ProductBrand> _BrandRepo { get; }
        public BrandsController(IGenericRepo<ProductBrand> BrandRepo)
        {
            _BrandRepo = BrandRepo;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductBrand>> GetBrandByID(Guid id)
        { 
            var b = await _BrandRepo.GetByIdAsync(id);
            if (b == null) return NotFound();
            return Ok(b);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetAllBrands()
        {
            var brandSpec = new BrandSpec();
            var b = await _BrandRepo.GetAllWithSpecificationAsync(brandSpec);
            return Ok(b);
        }
    }
}

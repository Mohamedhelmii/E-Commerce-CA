using AutoMapper;
using E_Commerce.Core.DTOs;
using E_Commerce.Core.Entities.ProductAggregate;
using E_Commerce.Core.Services;
using E_Commerce.Core.Specification.ProductSpec;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.APIs.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class BrandsController : BaseApiController
    {
        private IGenericRepo<ProductBrand> _BrandRepo { get; }
        private readonly IMapper _mapper;

        public BrandsController(IGenericRepo<ProductBrand> BrandRepo, IMapper mapper)
        {
            _BrandRepo = BrandRepo;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BrandsToReturnDTO>> GetBrandByID(Guid id)
        {
            var b = await _BrandRepo.GetByIdAsync(id);
            if (b == null) return NotFound();
            return Ok(_mapper.Map<ProductBrand, BrandsToReturnDTO>(b));
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<BrandsToReturnDTO>>> GetAllBrands()
        {
            var brandSpec = new BrandSpec();
            var b = await _BrandRepo.GetAllWithSpecificationAsync(brandSpec);
            return Ok(_mapper.Map<IReadOnlyList<ProductBrand>, IReadOnlyList<BrandsToReturnDTO>>(b));
        }

        #region Old before use mapping
        //[HttpGet("{id}")]
        //public async Task<ActionResult<ProductBrand>> GetBrandByID(Guid id)
        //{
        //    var b = await _BrandRepo.GetByIdAsync(id);
        //    if (b == null) return NotFound();
        //    return Ok(b);
        //}

        //[HttpGet]
        //public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetAllBrands()
        //{
        //    var brandSpec = new BrandSpec();
        //    var b = await _BrandRepo.GetAllWithSpecificationAsync(brandSpec);
        //    return Ok(b);
        //}
        #endregion
    }
}

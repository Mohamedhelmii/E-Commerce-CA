using AutoMapper;
using E_Commerce.Core.DTOs;
using E_Commerce.Core.Entities.ProductAggregate;
using E_Commerce.Core.Services;
using E_Commerce.Core.Specification.ProductSpec;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private IGenericRepo<ProductCategory> _CategoryRepo { get; }
        private readonly IMapper _mapper;
     
        public CategoriesController(IGenericRepo<ProductCategory> CategoryRepo, IMapper mapper)
        {
            _CategoryRepo = CategoryRepo;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoeiesToReturnDTO>> GetCategoryByID(Guid id)
        {
            var c = await _CategoryRepo.GetByIdAsync(id);
            if (c == null) return NotFound();
            return Ok(_mapper.Map<ProductCategory, CategoeiesToReturnDTO>(c));
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<CategoeiesToReturnDTO>>> GetAllCategories()
        {
            var categorySpec = new CategorySpec();
            var c = await _CategoryRepo.GetAllWithSpecificationAsync(categorySpec);
            return Ok(_mapper.Map<IReadOnlyList<ProductCategory>, IReadOnlyList<CategoeiesToReturnDTO>>(c));
        }
        #region old before use mapping
        //[HttpGet("{id}")]
        //public async Task<ActionResult<ProductCategory>> GetCategoryByID(Guid id)
        //{
        //    var c = await _CategoryRepo.GetByIdAsync(id);
        //    if (c == null) return NotFound();
        //    return Ok(c);
        //}

        //[HttpGet]
        //public async Task<ActionResult<IReadOnlyList<ProductCategory>>> GetAllCategories()
        //{
        //    var categorySpec = new CategorySpec();
        //    var c = await _CategoryRepo.GetAllWithSpecificationAsync(categorySpec);
        //    return Ok(c);
        //}
        #endregion
    }
}

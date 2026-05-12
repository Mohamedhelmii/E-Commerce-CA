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
    public class ProductController : BaseApiController
    {
        private readonly IGenericRepo<Product> _ProductRepo;
        private readonly IMapper _Mapper;

        public ProductController(IGenericRepo<Product> ProductRepo, IMapper mapper)
        {
            _ProductRepo = ProductRepo;
            _Mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToRetyrnDTO>> GetProductById(Guid id)
        {
            var ProductSpec = new ProductsWithCategoriesAndBrandsSpec(id);
            var p = await _ProductRepo.GetEntityWithSpecifcationAsync(ProductSpec);
            if (p == null) return NotFound();
            return Ok(_Mapper.Map<Product, ProductToRetyrnDTO>(p));
        }

        /// <param name="sort">Can be: priceAsc, priceDesc, or default (Name)</param>
        // add filtering and search by name
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToRetyrnDTO>>> GetAllProducts([FromQuery] ProductSpecParams productSpecParams)
            //(string? sort, Guid? BrandIdFilter, Guid? CategoryIdFilter, string? Search)
        {
            var ProductsSpec = new ProductsWithCategoriesAndBrandsSpec(productSpecParams);//(sort, BrandIdFilter, CategoryIdFilter, Search);
            var p = await _ProductRepo.GetAllWithSpecificationAsync(ProductsSpec);
            return Ok(_Mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToRetyrnDTO>>(p));
        }

        #region After using specification
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Product>> GetProductById(Guid id)
        //{
        //    var ProductSpec = new ProductsWithCategoriesAndBrandsSpec(id);
        //    var p = await _ProductRepo.GetEntityWithSpecifcationAsync(ProductSpec);
        //    if (p == null) return NotFound();
        //    return Ok(p);
        //}


        //[HttpGet]
        //public async Task<ActionResult<IReadOnlyList<Product>>> GetAllProducts()
        //{
        //    var ProductsSpec = new ProductsWithCategoriesAndBrandsSpec();
        //    var p = await _ProductRepo.GetAllWithSpecificationAsync(ProductsSpec);
        //    return Ok(p);
        //}
        #endregion
        #region old

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Product>> GetProductById(Guid id)
        //{
        //    var p = await _ProductRepo.GetByIdAsync(id);
        //    if (p == null) return NotFound();
        //    return Ok(p);
        //}

        //[HttpGet]
        //public async Task<ActionResult<IReadOnlyList<Product>>> GetAllProducts()
        //{
        //    var p = await _ProductRepo.GetAllAsync();
        //    return Ok(p);
        //}


        #endregion
    }
}

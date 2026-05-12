using E_Commerce.Core.Entities.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Specification.ProductSpec
{
    public class ProductsWithCategoriesAndBrandsSpec : BaseSpecification<Product>
    {
        public ProductsWithCategoriesAndBrandsSpec(Guid id) : base(p => p.Id == id)
        {
            AddInclude(p => p.Brand);
            AddInclude(p => p.Category);
        }

        // after using productSpecParams
        public ProductsWithCategoriesAndBrandsSpec(ProductSpecParams productSpecParams)
            //(string? sort = null, Guid? BrandIdFilter = null, Guid? CategoryIdFilter = null, string? Search = null)
            // add filtering and search by name
            :base(p => 
            (!productSpecParams.BrandIdFilter.HasValue || p.BrandId == productSpecParams.BrandIdFilter)&&
            (!productSpecParams.CategoryIdFilter.HasValue || p.CategoryId == productSpecParams.CategoryIdFilter) &&
            (string.IsNullOrEmpty(productSpecParams.Search) || p.Name.ToLower().Contains(productSpecParams.Search)))
        {
            AddInclude(p => p.Brand);
            AddInclude(p => p.Category);

            //for sorting
            AddOrderBy(x => x.Name);

            //for paging
            ApplyPaging(productSpecParams.PageSize * (productSpecParams.PageIndex - 1), productSpecParams.PageSize);

            if (!string.IsNullOrEmpty(productSpecParams.Sort))
            {
                switch (productSpecParams.Sort)
                {
                    case "priceAsc": 
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(p => p.Name);
                        break;
                }
            } 
        }
    }
}

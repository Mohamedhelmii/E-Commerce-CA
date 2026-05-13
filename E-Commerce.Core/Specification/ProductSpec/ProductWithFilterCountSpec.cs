using E_Commerce.Core.Entities.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Specification.ProductSpec
{
    public class ProductWithFilterCountSpec : BaseSpecification<Product>
    {
        public ProductWithFilterCountSpec(ProductSpecParams productSpecParams) 
            : base( p =>
            (!productSpecParams.BrandIdFilter.HasValue || p.BrandId == productSpecParams.BrandIdFilter) &&
            (!productSpecParams.CategoryIdFilter.HasValue || p.CategoryId == productSpecParams.CategoryIdFilter) &&
            (string.IsNullOrEmpty(productSpecParams.Search) || p.Name.ToLower().Contains(productSpecParams.Search))
            )
        {
        }
    }
}

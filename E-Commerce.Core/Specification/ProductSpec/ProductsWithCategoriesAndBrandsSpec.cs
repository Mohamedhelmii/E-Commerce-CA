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
        public ProductsWithCategoriesAndBrandsSpec(string? sort = null)
        {
            AddInclude(p => p.Brand);
            AddInclude(p => p.Category);

            //for sorting
            AddOrderBy(x => x.Name);

            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
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

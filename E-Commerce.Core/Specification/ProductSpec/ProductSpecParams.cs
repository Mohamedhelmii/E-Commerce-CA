using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Specification.ProductSpec
{
    // this class for simplify paramter of constructor
    public class ProductSpecParams
    {
        public string? Sort {  get; set; } =  null;
        public Guid? BrandIdFilter { get; set; } = null;
        public Guid? CategoryIdFilter { get; set; } = null;
        private string? _search { get; set; } = null;
        public string? Search
        {
            get => _search;
            set => _search = value?.ToLower(); 
        }
        private const int MaxPageSize = 50;
        public int PageIndex { get; set; } = 1;
        private int _pageSize { get; set; } = 6;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }


    }
}

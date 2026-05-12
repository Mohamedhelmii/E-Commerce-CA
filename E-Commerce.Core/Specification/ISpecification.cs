using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace E_Commerce.Core.Specification
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }

        List<Expression<Func<T, object>>> Includes { get; }


        // For sorting
        Expression<Func<T, Object>> OrderBY { get; }
        Expression<Func<T, object>> OrderBYDescending { get; }

        // For Pagination
        int Take { get; }
        int Skip { get; }
        bool IsPagingEnable { get; }
    }
}

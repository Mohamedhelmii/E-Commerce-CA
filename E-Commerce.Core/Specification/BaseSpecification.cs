using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Specification
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification() { }
        public BaseSpecification(Expression<Func<T, bool>> _Criteria) 
        {
            Criteria = _Criteria;
        }
        public Expression<Func<T, bool>> Criteria { get; }
        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        protected void AddInclude(Expression<Func<T, object>> include)
        {
            Includes.Add(include);
        }
        // for sorting
        public Expression<Func<T, object>> OrderBY { get; private set; }
        public Expression<Func<T, object>> OrderBYDescending { get; private set; }
        protected void AddOrderBy(Expression<Func<T, object>> orderBy) => OrderBY = orderBy;
        protected void AddOrderByDescending(Expression<Func<T, object>> orderBy) => OrderBYDescending = orderBy;

    }
}

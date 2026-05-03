using E_Commerce.Core.Entities;
using E_Commerce.Core.Specification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repository.Specification
{
    public class SpecificationEvaluator<T> where T : BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> specification) 
        {
            var query = inputQuery;
            if(specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);
            }
            
            query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));
            
            return query;
        }
    }   
}

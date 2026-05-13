using E_Commerce.Core.Entities;
using E_Commerce.Core.Services;
using E_Commerce.Core.Specification;
using E_Commerce.Repository.Data;
using E_Commerce.Repository.Specification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repository.Repository
{
    public class GenericRepo<T> : IGenericRepo<T> where T : BaseEntity
    {
        private readonly StoreContext sContext;
        private readonly DbSet<T> dbSet;
        public GenericRepo(StoreContext _storeContext)
        {
            sContext = _storeContext;
            dbSet = sContext.Set<T>();
        }
        async Task<T?> IGenericRepo<T>.GetByIdAsync(Guid id)
        {
            return await dbSet.FindAsync(id);
        }
        async Task<IReadOnlyList<T>> IGenericRepo<T>.GetAllAsync()
        {
            return await dbSet.AsNoTracking().ToListAsync();
        }

        // add implemntation of specifcation and add method to apply Evaluator
        private IQueryable<T> ApplySpecification(ISpecification<T> specification)
        {
            return SpecificationEvaluator<T>.GetQuery(dbSet, specification);
        }
        public async Task<T?> GetEntityWithSpecifcationAsync(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllWithSpecificationAsync(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).ToListAsync();
        }
        // add implementaion of count
        public async Task<int> CountAsync(ISpecification<T> specification)
        {
           return await ApplySpecification(specification).CountAsync();
        }
    }
}

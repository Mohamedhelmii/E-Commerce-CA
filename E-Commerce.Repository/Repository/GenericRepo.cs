using E_Commerce.Core.Entities;
using E_Commerce.Core.Services;
using E_Commerce.Repository.Data;
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
    }
}

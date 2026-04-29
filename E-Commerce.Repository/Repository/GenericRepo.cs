using E_Commerce.Core.Entities;
using E_Commerce.Core.Interface;
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
        public GenericRepo(StoreContext _storeContext)
        {
            sContext = _storeContext;
        }
        async Task<T?> IGenericRepo<T>.GetByIdAsync(Guid id)
        {
            return await sContext.Set<T>().FindAsync(id);
        }
        async Task<IReadOnlyList<T>> IGenericRepo<T>.GetAllAsync()
        {
            return await sContext.Set<T>().ToListAsync();
        }
    }
}

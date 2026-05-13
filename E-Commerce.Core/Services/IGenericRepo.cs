using E_Commerce.Core.Entities;
using E_Commerce.Core.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Services
{
    public interface IGenericRepo<T> where T : BaseEntity
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<IReadOnlyList<T>> GetAllAsync();

        //Add Specification Method
        Task<T?> GetEntityWithSpecifcationAsync(ISpecification<T> specification);
        Task<IReadOnlyList<T>> GetAllWithSpecificationAsync(ISpecification<T> specification);

        // add method for count
        Task<int> CountAsync(ISpecification<T> specification);
    }
}

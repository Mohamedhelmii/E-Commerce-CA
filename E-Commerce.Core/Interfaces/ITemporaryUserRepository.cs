using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.Core.Entities;

namespace E_Commerce.Core.Interfaces
{
    public interface ITemporaryUserRepository
    {
        Task<UserStoreTemporary> GetByEmailAsync(string email);
        Task AddAsync(UserStoreTemporary user);
        Task UpdateAsync(UserStoreTemporary user);
        Task DeleteAsync(UserStoreTemporary user);
    }
}
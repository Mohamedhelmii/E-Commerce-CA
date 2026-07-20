using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.Core.Entities;

namespace E_Commerce.Core.Interfaces
{
    public interface IResetPasswordTempRepository
    {
        Task<ResetPasswordTemp> GetByEmailAsync(string email);
        Task AddAsync(ResetPasswordTemp model);
        Task UpdateAsync(ResetPasswordTemp model);
        Task DeleteAsync(ResetPasswordTemp entity);
    }
}
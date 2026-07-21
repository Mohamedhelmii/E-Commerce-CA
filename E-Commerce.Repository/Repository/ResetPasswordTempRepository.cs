using E_Commerce.Core.Entities;
using E_Commerce.Core.Interfaces;
using E_Commerce.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repository.Repository
{
    public class ResetPasswordTempRepository : IResetPasswordTempRepository
    {
        private readonly StoreContext _context;

        public ResetPasswordTempRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<ResetPasswordTemp?> GetByEmailAsync(string email)
        {
            return await _context.ResetPasswordTemps.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task AddAsync(ResetPasswordTemp entity)
        {
            await _context.ResetPasswordTemps.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ResetPasswordTemp entity)
        {
            _context.ResetPasswordTemps.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ResetPasswordTemp entity)
        {
            _context.ResetPasswordTemps.Remove(entity);
            await _context.SaveChangesAsync();
        }



    }
}
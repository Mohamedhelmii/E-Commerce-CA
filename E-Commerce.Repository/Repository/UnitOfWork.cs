using E_Commerce.Core.Entities;
using E_Commerce.Core.Interfaces;
using E_Commerce.Repository.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repository.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreContext _storeContext;
        private readonly Hashtable _repo; // to carry classes
        public UnitOfWork(StoreContext storeContext)
        {
            _storeContext = storeContext;
            _repo = new Hashtable();
        }
        // to close connection at the end
        public async ValueTask DisposeAsync()
        {
            await _storeContext.DisposeAsync();
        }

        public IGenericRepo<TEntity> GenericRepo<TEntity>() where TEntity : BaseEntity
        {
            var typeName = typeof(TEntity).Name;
            if (!_repo.ContainsKey(typeName))
            {
                var repo = new GenericRepo<TEntity>(_storeContext);
                _repo.Add(typeName, repo);
            }
            return (IGenericRepo<TEntity>)_repo[typeName]!;
        }

        public Task<int> SaveAsync()
        {
            return _storeContext.SaveChangesAsync();
        }
    }
}

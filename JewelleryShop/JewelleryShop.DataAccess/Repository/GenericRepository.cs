
using JewelleryShop.DataAccess.Models;
using JewelleryShop.DataAccess.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;

namespace JewelleryShop.DataAccess.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected DbSet<T> _dbSet;
        public GenericRepository(JewelleryDBContext context) 
        {
            _dbSet = context.Set<T>();
        }

        public Task<List<T>> GetAllAsync() => _dbSet.ToListAsync();

        public async Task<T?> GetByIdAsync(int id)
        {
            var result = await _dbSet.FindAsync(id);
            return result;
        }
        public async Task<T?> GetByIdAsync(string id)
        {
            var result = await _dbSet.FindAsync(id);
            return result;
        }

        public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

        public async Task AddRangeAsync(List<T> entities) => await _dbSet.AddRangeAsync(entities);

        public void Remove(T entity) => _dbSet.Remove(entity);

        public void Update(T entity) => _dbSet.Update(entity);

        public void UpdateRange(List<T> entities) => _dbSet.UpdateRange(entities);

        public void RemoveRange(List<T> entities) => _dbSet.RemoveRange(entities);
    }
}

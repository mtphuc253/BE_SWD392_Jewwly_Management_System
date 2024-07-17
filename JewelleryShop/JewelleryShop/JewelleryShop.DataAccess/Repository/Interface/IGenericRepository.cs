
using JewelleryShop.DataAccess.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryShop.DataAccess.Repository.Interface
{
    public interface IGenericRepository<T> 
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<T?> GetByIdAsync(string id);
        Task AddAsync(T entity);
        Task AddRangeAsync(List<T> entities);
        void Update(T entity);
        void UpdateRange(List<T> entities);
        void Remove(T entity);
        void RemoveRange(List<T> entities);
        Task<Pagination<T>> ToPagination(int pageIndex = 0, int pageSize = 10);
    }
}

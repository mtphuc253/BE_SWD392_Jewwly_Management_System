using JewelleryShop.DataAccess.Models.dto;
using JewelleryShop.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryShop.Business.Service.Interface
{
    public interface IDiscountService
    {
        public Task<List<DiscountDto>> GetAllAsync();
        public Task<Discount> GetByIdAsync(int id);
        public Task Update(int id, DiscountDto dis);
        public Task AddAsync(Discount dis);
        public Task RemoveAsync(int id);
        public Task Approve(int id);
        public Task Request(int id);
    }
}

using JewelleryShop.DataAccess.Models;
using JewelleryShop.DataAccess.Models.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryShop.DataAccess.Repository.Interface
{
    public interface IItemRepository : IGenericRepository<Item>
    {
        
        void SoftDelete(Item item);
        List<Item?> GetByName(string name);

        public Task<List<Item>> GetAllBuyBackAsync();
    }
}

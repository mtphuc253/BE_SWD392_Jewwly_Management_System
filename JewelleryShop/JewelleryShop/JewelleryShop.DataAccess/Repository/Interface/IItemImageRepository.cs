using JewelleryShop.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryShop.DataAccess.Repository.Interface
{
    public interface IItemImageRepository: IGenericRepository<ItemImage>
    {
        public Task<ItemImage> UpdateAsync(string id, ItemImage itemImg);
        public Task DeleteAsync(string id);
        public Task<List<ItemImage>> GetItemImagesByItemID(string itemID, int? count = null);
    }
}

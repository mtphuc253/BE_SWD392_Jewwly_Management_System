using JewelleryShop.DataAccess.Models;
using JewelleryShop.DataAccess.Models.ViewModel.ItemImageViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryShop.Business.Service.Interface
{
    public interface IItemImageService
    {
        public Task<List<ItemImageCommonDTO>> GetAllItemImage();
        public Task<List<ItemImageCommonDTO>> GetItemImagesByItemID(string itemID, int? count = null);
        public Task<ItemImageCommonDTO> GetItemImageById(string id);
        public Task<ItemImageCommonDTO> AddItemImage(ItemImageInputDTO img);
        public Task<ItemImageCommonDTO> UpdateItemImageAsync(string id, ItemImageInputDTO imgDTO);
        public Task DeleteItemImageAsync(string id);
    }
}

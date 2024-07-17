using AnyAscii;
using AutoMapper;
using JewelleryShop.Business.Service.Interface;
using JewelleryShop.DataAccess;
using JewelleryShop.DataAccess.Models;
using JewelleryShop.DataAccess.Models.dto;
using JewelleryShop.DataAccess.Models.ViewModel.ItemViewModel;
using JewelleryShop.DataAccess.Repository.Interface;
using JewelleryShop.DataAccess.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryShop.Business.Service
{
    public class ItemService : IItemService
    {
        // dependency injection
        
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ItemService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        private string RemoveDiacritics(string text)
        {

            return text.Transliterate();
        }
        private string GenerateItemId(string name, DateTime creationDate)
        {
            name = RemoveDiacritics(name);
            var initials = string.Join("", name.Split(' ').Take(3).Select(x => x[0]).ToArray()).ToUpper();
            var formattedDate = creationDate.ToString("ddMMyyHHmmss");
            return $"{initials}{formattedDate}";
        }

        public async Task AddAsync(ItemCreateDTO item)
        {
            var itemID = GenerateItemId(item.ItemName, DateTime.Now);
            var itemToAdd = _mapper.Map<Item>(item);
            itemToAdd.ItemId = itemID;
            itemToAdd.SerialNumber = itemID;
            await _unitOfWork.ItemRepository.AddAsync(itemToAdd);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<List<Item>> GetAllAsync()
        {
            return await _unitOfWork.ItemRepository.GetAllAsync();
        }

        public async Task<Item> GetByIdAsync(string id)
        {
            return await _unitOfWork.ItemRepository.GetByIdAsync(id);
        }

        public async Task RemoveAsync(string id)
        {
            var item = await GetByIdAsync(id);
            if (item != null)
            {
                _unitOfWork.ItemRepository.Remove(item);
                _unitOfWork.SaveChangeAsync();
            }
            else
            {
                throw new Exception("Can not delete Item");
            }
        }

        public async Task SoftDelete(string id)
        {
            var item = await GetByIdAsync(id);
            if (item != null)
            {
                item.Status = "Hết hàng";
                _unitOfWork.ItemRepository.Update(item);
                await _unitOfWork.SaveChangeAsync();
            }
            else 
            {
                throw new Exception("Can not update Item status");
            }
        }

        public async Task UpdateItemAsync(string id, ItemDTO item)
        {
            var itemToUpdate = await GetByIdAsync(id);
     
            if (itemToUpdate != null)
            {
                itemToUpdate = _mapper.Map<ItemDTO, Item>(item, itemToUpdate);
                _unitOfWork.ItemRepository.Update(itemToUpdate);
                await _unitOfWork.SaveChangeAsync();
            }
            else
            {
                throw new Exception("Can not update Item");
            }
        }

        public async Task<Pagination<Item>> GetPaginatedItemsAsync(int pageIndex, int pageSize)
        {
            return await _unitOfWork.ItemRepository.ToPagination(pageIndex, pageSize);
        }

        public List<Item> SearchByName(string itemName)
        {
            return _unitOfWork.ItemRepository.GetByName(itemName);
        }

        public async Task UpdateQuantityAsync(string id, int quantity)
        {
            var itemToUpdate = await GetByIdAsync(id);
            if (quantity == 0) 
            {
                throw new Exception("The quantity entered is invalid...!!!");
            }
            if (quantity >= 1 && itemToUpdate.Quantity >= quantity)
            {
                int newQuantity = (int)itemToUpdate.Quantity - quantity;
                itemToUpdate.Quantity = newQuantity;
                if (itemToUpdate.Quantity == 0)
                {
                    string itemId = itemToUpdate.ItemId.ToString();
                    await SoftDelete(itemId);
                }
                _unitOfWork.ItemRepository.Update(itemToUpdate);
                await _unitOfWork.SaveChangeAsync();
            }
            else
            {
                throw new Exception("The quantity entered is greater than the amount of stock in the store...!!!");
            }

        }

        public async Task<List<ItemDTO>> GetAllBuyBackAsync()
        {
            return _mapper.Map<List<ItemDTO>>(await _unitOfWork.ItemRepository.GetAllBuyBackAsync());
        }
    }
}

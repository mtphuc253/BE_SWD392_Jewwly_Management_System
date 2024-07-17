using AutoMapper;
using JewelleryShop.Business.Service.Interface;
using JewelleryShop.DataAccess;
using JewelleryShop.DataAccess.Models;
using JewelleryShop.DataAccess.Models.ViewModel.CollectionViewModel;
using JewelleryShop.DataAccess.Models.ViewModel.ItemImageViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryShop.Business.Service
{
    public class ItemImageService : IItemImageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ItemImageService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<ItemImageCommonDTO>> GetAllItemImage()
        {
            var images = await _unitOfWork.ItemImageRepository.GetAllAsync();
            return _mapper.Map<List<ItemImageCommonDTO>>(images);
        }

        public async Task<ItemImageCommonDTO> GetItemImageById(string id)
        {
            var images = await _unitOfWork.ItemImageRepository.GetByIdAsync(id);
            return _mapper.Map<ItemImageCommonDTO>(images);
        }

        public async Task<List<ItemImageCommonDTO>> GetItemImagesByItemID(string itemID, int? count = null)
        {
            var itemImgs = await _unitOfWork.ItemImageRepository.GetItemImagesByItemID(itemID, count);
            
            return _mapper.Map<List<ItemImageCommonDTO>>(itemImgs);
        }

        public async Task<ItemImageCommonDTO> AddItemImage(ItemImageInputDTO img)
        {
            var img_items = _mapper.Map<ItemImage>(img);
            img_items.Id = Guid.NewGuid().ToString();
            await _unitOfWork.ItemImageRepository.AddAsync(img_items);
            await _unitOfWork.SaveChangeAsync();
            return _mapper.Map<ItemImageCommonDTO>(img_items);
        }

        public async Task<ItemImageCommonDTO> UpdateItemImageAsync(string id, ItemImageInputDTO imgDTO)
        {
            var img_items = await _unitOfWork.ItemImageRepository.GetByIdAsync(id);
            if (img_items == null)
            {
                throw new Exception("Items not found.");
            }
            img_items = _mapper.Map<ItemImageInputDTO, ItemImage>(imgDTO, img_items);

            await _unitOfWork.ItemImageRepository.UpdateAsync(id, img_items);
            await _unitOfWork.SaveChangeAsync();

            return _mapper.Map<ItemImageCommonDTO>(img_items);
        }

        public async Task DeleteItemImageAsync(string id)
        {
            var img_items = await _unitOfWork.ItemImageRepository.GetByIdAsync(id);
            if (img_items != null)
            {
                await _unitOfWork.ItemImageRepository.DeleteAsync(id);
                await _unitOfWork.SaveChangeAsync();
            }
            else
            {
                throw new ArgumentException("No Items found with the provided ID.");
            }
        }


    }
}

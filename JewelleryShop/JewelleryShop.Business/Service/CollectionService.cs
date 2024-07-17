using AutoMapper;
using JewelleryShop.Business.Service.Interface;
using JewelleryShop.DataAccess;
using JewelleryShop.DataAccess.Models;
using JewelleryShop.DataAccess.Models.ViewModel.CollectionViewModel;
using JewelleryShop.DataAccess.Models.ViewModel.InvoiceViewModel;
using JewelleryShop.DataAccess.Models.ViewModel.StaffViewModel;
using JewelleryShop.DataAccess.Models.ViewModel.WarrantyViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryShop.Business.Service
{
    public class CollectionService: ICollectionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CollectionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<CollectionCommonDTO>> GetAllCollection()
        {
            var collections = await _unitOfWork.CollectionRepository.GetAllAsync();
            return _mapper.Map<List<CollectionCommonDTO>>(collections);
        }

        public async Task<CollectionCommonDTO> GetCollectionById(string id)
        {
            var collections = await _unitOfWork.CollectionRepository.GetByIdAsync(id);
            return _mapper.Map<CollectionCommonDTO>(collections);
        }

        public async Task<CollectionCommonDTO> AddCollection(CollectionInputDTO collection)
        {
            var collections = _mapper.Map<Collection>(collection);
            collections.Id = Guid.NewGuid().ToString();
            await _unitOfWork.CollectionRepository.AddAsync(collections);
            await _unitOfWork.SaveChangeAsync();
            return _mapper.Map<CollectionCommonDTO>(collections);
        }

        public async Task<CollectionCommonDTO> UpdateCollectionAsync(string id, CollectionInputDTO collectionDTO)
        {
            var collections = await _unitOfWork.CollectionRepository.GetByIdAsync(id);
            if (collections == null)
            {
                throw new Exception("Collection not found.");
            }
            collections = _mapper.Map<CollectionInputDTO, Collection>(collectionDTO, collections);

            await _unitOfWork.CollectionRepository.UpdateAsync(id, collections);
            await _unitOfWork.SaveChangeAsync();

            return _mapper.Map<CollectionCommonDTO>(collections);
        }

        public async Task DeleteCollectionAsync(string id)
        {
            var collection = await _unitOfWork.CollectionRepository.GetByIdAsync(id);
            if (collection != null)
            {
                await _unitOfWork.CollectionRepository.DeleteAsync(id);
                await _unitOfWork.SaveChangeAsync();
            }
            else
            {
                throw new ArgumentException("No Collection found with the provided ID.");
            }
        }
    }
}

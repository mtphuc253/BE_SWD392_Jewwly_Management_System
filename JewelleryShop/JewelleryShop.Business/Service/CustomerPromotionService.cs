using AnyAscii;
using AutoMapper;
using JewelleryShop.Business.Service.Interface;
using JewelleryShop.DataAccess;
using JewelleryShop.DataAccess.Models;
using JewelleryShop.DataAccess.Models.ViewModel.PromotionViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryShop.Business.Service
{
    public class CustomerPromotionService : ICustomerPromotionService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerPromotionService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(CustomerPromotionDto obj)
        {
            string ID = Guid.NewGuid().ToString();
            obj.Status = "Chờ duyệt";
            var promotionToAdd = _mapper.Map<CustomerPromotion>(obj);
            promotionToAdd.Id = ID;
            await _unitOfWork.CustomerPromotionRepository.AddAsync(promotionToAdd);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task Approve(string id)
        {
            var obj = await _unitOfWork.CustomerPromotionRepository.GetByIdAsync(id);
            obj.Status = "Duyệt";
            _unitOfWork.CustomerPromotionRepository.Update(obj);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task Delete(string id)
        {
            var obj = await _unitOfWork.CustomerPromotionRepository.GetByIdAsync(id);
            _unitOfWork.CustomerPromotionRepository.Remove(obj);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<List<CustomerPromotion>> GetAll()
        {
            return await _unitOfWork.CustomerPromotionRepository.GetAllAsync();
        }

        public async Task Update(string id, CustomerPromotionDto obj)
        {
            var promotionToUpdate = await _unitOfWork.CustomerPromotionRepository.GetByIdAsync(id);

            if (promotionToUpdate != null)
            {
                _mapper.Map(obj, promotionToUpdate);
                _unitOfWork.CustomerPromotionRepository.Update(promotionToUpdate);
                await _unitOfWork.SaveChangeAsync();
            }
        }
    }
}

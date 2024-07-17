using AutoMapper;
using JewelleryShop.Business.Service.Interface;
using JewelleryShop.DataAccess;
using JewelleryShop.DataAccess.Models;
using JewelleryShop.DataAccess.Models.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryShop.Business.Service
{
    public class DiscountService : IDiscountService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DiscountService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(Discount dis)
        {
            var newDis = _mapper.Map<Discount>(dis);
            await _unitOfWork.DiscountRepository.AddAsync(newDis);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task Approve(int id)
        {
            var dis = await GetByIdAsync(id);
            dis.Status = "Duyệt";
            _unitOfWork.DiscountRepository.Update(dis);
            _unitOfWork.SaveChangeAsync();
        }

        public async Task<List<DiscountDto>> GetAllAsync()
        {
            var discounts = _mapper.Map<List<DiscountDto>>(await _unitOfWork.DiscountRepository.GetAllAsync());
            return discounts;
        }

        public async Task<Discount> GetByIdAsync(int id)
        {
            return await _unitOfWork.DiscountRepository.GetByIdAsync(id);
        }

        public async Task RemoveAsync(int id)
        {
            var dis = await GetByIdAsync(id);
            _unitOfWork.DiscountRepository.Remove(dis);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task Request(int id)
        {
            var dis = await GetByIdAsync(id);
            dis.Status = "Chờ duyệt";
            _unitOfWork.DiscountRepository.Update(dis);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task Update(int id, DiscountDto dis)
        {
            var disToUpdate = await GetByIdAsync(id);

            if (disToUpdate != null)
            {
                _mapper.Map(dis, disToUpdate);
                _unitOfWork.DiscountRepository.Update(disToUpdate);
                await _unitOfWork.SaveChangeAsync();
            }
        }
    }
}

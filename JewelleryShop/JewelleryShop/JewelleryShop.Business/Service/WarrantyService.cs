using AutoMapper;
using JewelleryShop.Business.Service.Interface;
using JewelleryShop.DataAccess.Models.ViewModel.WarrantyViewModel;
using JewelleryShop.DataAccess.Models;
using JewelleryShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryShop.Business.Service
{
    public class WarrantyService : IWarrantyService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public WarrantyService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<WarrantyCommonDTO>> GetAllWarranty()
        {
            var warranties = await _unitOfWork.WarrantyRepository.GetAllAsync();
            var warrantyDTOs = _mapper.Map<IEnumerable<WarrantyCommonDTO>>(warranties);

            //foreach (var warranty in warrantyDTOs)
            //{
            //    if (warranty.ExpiryDate.HasValue)
            //    {
            //        warranty.ExpiryDateValue = warranty.ExpiryDate.Value.ToString("dd-MM-yyyy");
            //    }
            //}

            return warrantyDTOs;
        }

        public async Task<WarrantyCommonDTO> GetWarrantyById(string id)
        {
            var warranty = await _unitOfWork.WarrantyRepository.GetByIdAsync(id);

            if (warranty == null)
            {
                return null;
            }

            var warrantyDto = _mapper.Map<WarrantyCommonDTO>(warranty);

            //if (warrantyDto.ExpiryDate.HasValue)
            //{
            //    warrantyDto.ExpiryDateValue = warrantyDto.ExpiryDate.Value.ToString("dd-MM-yyyy");
            //}

            return warrantyDto;
        }

        public async Task<WarrantyCommonDTO> AddWarranty(WarrantyInputDTO warrantyDto)
        {
            Warranty warrantyEntity = _mapper.Map<Warranty>(warrantyDto);
            await _unitOfWork.WarrantyRepository.AddWarranty(warrantyEntity);
            await _unitOfWork.SaveChangeAsync();
            return _mapper.Map<WarrantyCommonDTO>(warrantyEntity);
        }
    }
}
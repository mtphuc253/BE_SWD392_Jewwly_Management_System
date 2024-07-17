using AutoMapper;
using JewelleryShop.Business.Service.Interface;
using JewelleryShop.DataAccess;
using JewelleryShop.DataAccess.Models;
using JewelleryShop.DataAccess.Models.ViewModel.CollectionViewModel;
using JewelleryShop.DataAccess.Models.ViewModel.GemstoneViewModel;
using JewelleryShop.DataAccess.Models.ViewModel.InvoiceViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryShop.Business.Service
{
    public class GemstoneService: IGemstoneService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GemstoneService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<GemstoneCommonDTO>> GetAllGemstones()
        {
            var gemstone = await _unitOfWork.GemstoneRepository.GetAllAsync();
            return _mapper.Map<List<GemstoneCommonDTO>>(gemstone);
        }

        public async Task<GemstoneCommonDTO> GetGemstoneById(string id)
        {
            var gemstone = await _unitOfWork.GemstoneRepository.GetByIdAsync(id);
            return _mapper.Map<GemstoneCommonDTO>(gemstone);
        }

        public async Task<GemstoneCommonDTO> AddGemstone(GemstoneInputDTO gemstone)
        {
            var gem = _mapper.Map<Gemstone>(gemstone);
            gem.Id = Guid.NewGuid().ToString();
            await _unitOfWork.GemstoneRepository.AddAsync(gem);
            await _unitOfWork.SaveChangeAsync();
            return _mapper.Map<GemstoneCommonDTO>(gem);
        }

        public async Task<GemstoneCommonDTO> UpdateGemstoneAsync(string id, GemstoneInputDTO gemstoneDTO)
        {
            var gemstone = await _unitOfWork.GemstoneRepository.GetByIdAsync(id);
            if (gemstone == null)
            {
                throw new Exception("Gemstone not found.");
            }
            gemstone = _mapper.Map<GemstoneInputDTO, Gemstone>(gemstoneDTO, gemstone);

            await _unitOfWork.GemstoneRepository.UpdateAsync(id, gemstone);
            await _unitOfWork.SaveChangeAsync();

            return _mapper.Map<GemstoneCommonDTO>(gemstone);
        }

        public async Task DeleteGemstoneAsync(string id)
        {
            var gemstone = await _unitOfWork.GemstoneRepository.GetByIdAsync(id);
            if (gemstone != null)
            {
                await _unitOfWork.GemstoneRepository.DeleteAsync(id);
                await _unitOfWork.SaveChangeAsync();
            }
            else
            {
                throw new ArgumentException("No Gemstone found with the provided ID.");
            }
        }
    }
}

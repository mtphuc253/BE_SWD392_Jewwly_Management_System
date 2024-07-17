using AutoMapper;
using JewelleryShop.Business.Service.Interface;
using JewelleryShop.DataAccess;
using JewelleryShop.DataAccess.Models;
using JewelleryShop.DataAccess.Models.ViewModel.StaffShiftViewsModel;
using JewelleryShop.DataAccess.Models.ViewModel.StaffViewModel;
using JewelleryShop.DataAccess.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryShop.Business.Service
{
    public class StaffStationService : IStaffStationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StaffStationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<StaffShiftCommonDTO>> GetAllStaffShifts()
        {
            var staffShifts = await _unitOfWork.StaffStationRepository.GetAllAsync();
            return _mapper.Map<List<StaffShiftCommonDTO>>(staffShifts);
        }

        public async Task<StaffShiftCommonDTO> GetStaffShiftById(string id)
        {
            var staffShift = await _unitOfWork.StaffStationRepository.GetByIdAsync(id);
            return _mapper.Map<StaffShiftCommonDTO>(staffShift);
        }

        public async Task<StaffShiftCommonDTO> AddStaffShift(StaffShiftInputDTO staffShiftDTO)
        {
            var staffShift = _mapper.Map<StaffStation>(staffShiftDTO);
            staffShift.StationId = Guid.NewGuid().ToString();
            await _unitOfWork.StaffStationRepository.AddAsync(staffShift);
            await _unitOfWork.SaveChangeAsync();

            return _mapper.Map<StaffShiftCommonDTO>(staffShift);
        }

        public async Task<StaffShiftCommonDTO> UpdateStaffShiftAsync(string id, StaffShiftInputDTO station)
        {
            var shift = await _unitOfWork.StaffStationRepository.GetByIdAsync(id);
            if (shift == null) { throw new ArgumentException("Shift not found!"); }
            _mapper.Map(station, shift);
            await _unitOfWork.StaffStationRepository.UpdateAsync(id, shift);
            await _unitOfWork.SaveChangeAsync();

            return _mapper.Map<StaffShiftCommonDTO>(shift);
        }

        public async Task DeleteShiftAsync(string id)
        {
            var shift = await _unitOfWork.StaffStationRepository.GetByIdAsync(id);
            if (shift != null)
            {
                await _unitOfWork.StaffStationRepository.DeleteAsync(id);
                await _unitOfWork.SaveChangeAsync();
            }
            else
            {
                throw new ArgumentException("No shift found with the provided ID.");
            }
        }
    }
}

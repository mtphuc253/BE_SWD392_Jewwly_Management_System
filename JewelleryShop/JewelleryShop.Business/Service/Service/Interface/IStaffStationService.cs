using JewelleryShop.DataAccess.Models.ViewModel.StaffShiftViewsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryShop.Business.Service.Interface
{
    public interface IStaffStationService
    {
        public Task<List<StaffShiftCommonDTO>> GetAllStaffShifts();
        public Task<StaffShiftCommonDTO> GetStaffShiftById(string id);
        public Task<StaffShiftCommonDTO> AddStaffShift(StaffShiftInputDTO staffShiftDTO);

        public Task<StaffShiftCommonDTO> UpdateStaffShiftAsync(string id, StaffShiftInputDTO station);
        public Task DeleteShiftAsync(string id);
    }
}

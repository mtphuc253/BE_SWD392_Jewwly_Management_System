using JewelleryShop.DataAccess.Models;
using JewelleryShop.DataAccess.Models.ViewModel.StaffViewModel;
using JewelleryShop.DataAccess.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryShop.Business.Service.Interface
{
    public interface IStaffService
    {
        public Task<string> LoginAsync(StaffLoginDTO employee);
        public Task<StaffCommonDTO> AddEmployeeAsync(StaffRegisterDTO employee);
        public void DisableAccount( staff staff);

        public Task<List<StaffCommonDTO>> GetAllStaff();

        public Task<StaffCommonDTO> GetStaffById(string id);
        public Task<StaffCommonDTO> UpdateEmployeeAsync(string id, StaffRegisterDTO employeeDTO);
        public Task DeleteEmployeeAsync(string id);
    }
}

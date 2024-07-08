using JewelleryShop.DataAccess.Models.ViewModel.ReturnPolicyViewModel;
using JewelleryShop.DataAccess.Models;
using JewelleryShop.DataAccess.Models.ViewModel.WarrantyViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryShop.Business.Service.Interface
{
    public interface IReturnPolicyService
    {
        public Task<ReturnPolicyCommonDTO> CreateReturnPolicy(ReturnPolicyCreateDTO returnPolicy);
        public Task<List<ReturnPolicyCommonDTO>> GetAllReturnPolicy();
        public Task<ReturnPolicyCommonDTO> GetReturnPolicyByID(string id);
        public Task<ReturnPolicyCommonDTO> UpdateReturnPolicy(string returnPolicyID, ReturnPolicyUpdateDTO returnPolicy);
        public Task DeleteReturnPolicy(string returnPolicyID);

    }
}

using JewelleryShop.DataAccess.Models.ViewModel.WarrantyViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryShop.Business.Service.Interface
{
    public interface IWarrantyService
    {
        Task<WarrantyCommonDTO> GetWarrantyById(string id);
        Task<IEnumerable<WarrantyCommonDTO>> GetAllWarranty();
        Task<WarrantyCommonDTO> AddWarranty(WarrantyInputDTO warrantyDto);
    }
}

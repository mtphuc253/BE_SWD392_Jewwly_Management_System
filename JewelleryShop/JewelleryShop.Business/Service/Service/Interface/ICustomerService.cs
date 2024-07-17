using JewelleryShop.DataAccess.Models;
using JewelleryShop.DataAccess.Models.ViewModel.CustomerViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryShop.Business.Service.Interface
{
    public interface ICustomerService
    {
        public Task<List<CustomerCommonDTO>> GetAllAsync();
        public Task<CustomerCommonDTO> GetByIDAsync(string id);
        public Task<CustomerCommonDTO> GetByEmailAsync(string email);
        public Task<CustomerCommonDTO> GetByPhoneNumberAsync(string phoneNumber);
        public Task<CustomerCommonDTO> CreateCustomerAsync(CustomerInputDTO customerData);
        public Task<CustomerInputDTO> UpdateCustomerAsync(string id, CustomerInputDTO newCustomerData);
    }
}

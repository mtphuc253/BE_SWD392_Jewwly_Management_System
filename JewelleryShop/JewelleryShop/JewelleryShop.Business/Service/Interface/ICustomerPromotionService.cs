using JewelleryShop.DataAccess.Models;
using JewelleryShop.DataAccess.Models.dto;
using JewelleryShop.DataAccess.Models.ViewModel.PromotionViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryShop.Business.Service.Interface
{
    public interface ICustomerPromotionService
    {
        public Task<List<CustomerPromotion>> GetAll();
        public Task AddAsync(CustomerPromotionDto obj);
        public Task Update(string id, CustomerPromotionDto obj);
        public Task Delete(string id);
        public Task Approve(string id);

    }
}

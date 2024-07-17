using JewelleryShop.DataAccess.Models;
using JewelleryShop.DataAccess.Models.ViewModel.PromotionViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryShop.DataAccess.Repository.Interface
{
    public interface ICustomerPromotionRepository : IGenericRepository<CustomerPromotion>
    {
        void Approve(CustomerPromotion promotion);
    }
}

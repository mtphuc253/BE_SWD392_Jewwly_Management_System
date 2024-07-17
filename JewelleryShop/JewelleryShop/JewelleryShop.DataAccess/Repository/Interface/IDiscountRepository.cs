using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JewelleryShop.DataAccess.Models;

namespace JewelleryShop.DataAccess.Repository.Interface
{
    public interface IDiscountRepository : IGenericRepository<Discount>
    {
        void Approve(Discount discount);
        void Request(Discount discount);
    }
}

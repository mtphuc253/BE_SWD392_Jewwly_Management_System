using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryShop.DataAccess.Models.ViewModel.PromotionViewModel
{
    public class CustomerPromotionDto
    {
        public string CusID { get; set; }
        public string Code { get; set; }
        public decimal  DiscountPct { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}

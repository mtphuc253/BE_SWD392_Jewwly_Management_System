using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryShop.DataAccess.Models.dto
{
    public class DiscountDto
    {
        public string DiscountCode { get; set; }
        public decimal DiscountPercentage { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}

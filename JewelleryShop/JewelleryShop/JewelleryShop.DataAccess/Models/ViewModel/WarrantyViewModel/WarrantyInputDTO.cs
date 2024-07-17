using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryShop.DataAccess.Models.ViewModel.WarrantyViewModel
{
    public class WarrantyInputDTO
    {
        public string? CustomerId { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}

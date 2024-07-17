using System;
using System.Collections.Generic;

namespace JewelleryShop.DataAccess.Models.ViewModel.WarrantyViewModel
{
    public partial class WarrantyCommonDTO
    {
        public string WarrantyId { get; set; } = null!;
        public string? CustomerId { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}

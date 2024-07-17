using System;
using System.Collections.Generic;

namespace JewelleryShop.DataAccess.Models
{
    public partial class CustomerPromotion
    {
        public CustomerPromotion()
        {
            Customers = new HashSet<Customer>();
        }

        public string Id { get; set; } = null!;
        public string? Code { get; set; }
        public decimal? DiscountPct { get; set; }
        public string? Status { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string? CusId { get; set; }
        public string? Description { get; set; }

        public virtual Customer? Cus { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}

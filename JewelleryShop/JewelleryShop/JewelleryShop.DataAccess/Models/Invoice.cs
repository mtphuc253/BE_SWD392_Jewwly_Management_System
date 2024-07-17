using System;
using System.Collections.Generic;

namespace JewelleryShop.DataAccess.Models
{
    public partial class Invoice
    {
        public Invoice()
        {
            ItemInvoices = new HashSet<ItemInvoice>();
        }

        public string Id { get; set; } = null!;
        public string? StaffId { get; set; }
        public string? ItemId { get; set; }
        public string? CustomerId { get; set; }
        public string? CompanyName { get; set; }
        public string? BuyerAddress { get; set; }
        public string? Status { get; set; }
        public string? PaymentType { get; set; }
        public int? Quantity { get; set; }
        public decimal? SubTotal { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual staff? Staff { get; set; }
        public virtual ICollection<ItemInvoice> ItemInvoices { get; set; }
    }
}

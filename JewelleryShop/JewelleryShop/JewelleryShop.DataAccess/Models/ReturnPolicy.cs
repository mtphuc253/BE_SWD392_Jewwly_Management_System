using System;
using System.Collections.Generic;

namespace JewelleryShop.DataAccess.Models
{
    public partial class ReturnPolicy
    {
        public ReturnPolicy()
        {
            ItemInvoices = new HashSet<ItemInvoice>();
        }

        public string Id { get; set; } = null!;
        public string? ReturnPolicyType { get; set; }
        public string? ReturnWindow { get; set; }
        public string? Description { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<ItemInvoice> ItemInvoices { get; set; }
    }
}

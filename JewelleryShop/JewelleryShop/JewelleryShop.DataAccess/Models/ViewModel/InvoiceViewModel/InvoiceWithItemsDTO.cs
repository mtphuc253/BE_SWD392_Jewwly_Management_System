using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryShop.DataAccess.Models.ViewModel.InvoiceViewModel
{
    public class InvoiceWithItemsDTO
    {
        public InvoiceCommonDTO InvoiceDetails { get; set; }
        public List<string> itemIds { get; set; }
        public string returnPolicyId { get; set; }
    }
}

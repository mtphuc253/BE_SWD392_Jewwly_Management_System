using JewelleryShop.DataAccess.Models;
using JewelleryShop.DataAccess.Models.ViewModel.InvoiceViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryShop.DataAccess.Repository.Interface
{
    public interface IInvoiceRepository : IGenericRepository<Invoice>
    {
        public Task<InvoiceCreateWithItemsDTO> CreateInvoiceWithItemsAsync(Invoice invoice, IEnumerable<InvoiceInputItemDTO> items);
        public Task<List<Item>> GetInvoiceItems(string invoiceID);
    }
}

using JewelleryShop.DataAccess.Models;
using JewelleryShop.DataAccess.Models.ViewModel.InvoiceViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryShop.Business.Service.Interface
{
    public interface IInvoiceService
    {
        Task<List<InvoiceCommonDTO>> GetAllInvoices();
        Task<InvoiceCommonDTO> GetInvoiceById(string id);
        Task<InvoiceCommonDTO> AddInvoice(InvoiceInputDTO invoiceDTO);
        Task<InvoiceCreateWithItemsDTO> CreateInvoiceWithItemsAsync(InvoiceInputNewDTO invoiceDTO, IEnumerable<InvoiceInputItemDTO> items);
        Task<List<Item>> GetInvoiceItems(string invoiceID);
        Task<List<KeyValuePair<string, decimal>>> GetMonthlyRevenue();
    }
}

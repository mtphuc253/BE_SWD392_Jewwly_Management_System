using AutoMapper;
using JewelleryShop.Business.Service.Interface;
using JewelleryShop.DataAccess.Models.ViewModel.InvoiceViewModel;
using JewelleryShop.DataAccess.Models;
using JewelleryShop.DataAccess;

public class InvoiceService : IInvoiceService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public InvoiceService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<InvoiceCommonDTO>> GetAllInvoices()
    {
        var invoices = await _unitOfWork.InvoiceRepository.GetAllAsync();
        return _mapper.Map<List<InvoiceCommonDTO>>(invoices);
    }

    public async Task<InvoiceCommonDTO> GetInvoiceById(string id)
    {
        var invoice = await _unitOfWork.InvoiceRepository.GetByIdAsync(id);
        return _mapper.Map<InvoiceCommonDTO>(invoice);
    }

    public async Task<InvoiceCommonDTO> AddInvoice(InvoiceInputDTO invoiceDTO)
    {
        var invoice = _mapper.Map<Invoice>(invoiceDTO);
        invoice.Id = Guid.NewGuid().ToString();
        await _unitOfWork.InvoiceRepository.AddAsync(invoice);
        await _unitOfWork.SaveChangeAsync();

        return _mapper.Map<InvoiceCommonDTO>(invoice);
    }

    public async Task<InvoiceCreateWithItemsDTO> CreateInvoiceWithItemsAsync(InvoiceInputNewDTO invoiceDTO, IEnumerable<InvoiceInputItemDTO> items)
    {
        var invoice = _mapper.Map<Invoice>(invoiceDTO);
        invoice.Id = Guid.NewGuid().ToString();
        var res = await _unitOfWork.InvoiceRepository.CreateInvoiceWithItemsAsync(invoice, items);
        await _unitOfWork.SaveChangeAsync();

        return res;
    }

    public async Task<List<Item>> GetInvoiceItems(string invoiceID)
    {
        var res = await _unitOfWork.InvoiceRepository.GetInvoiceItems(invoiceID);
        return res;
    }

    public async Task<List<KeyValuePair<string, decimal>>> GetMonthlyRevenue()
    {
        var invoices = await _unitOfWork.InvoiceRepository.GetAllAsync();
        var validInvoices = invoices.Where(i => i.CreatedDate.HasValue);
        var monthlyRevenue = validInvoices
            .GroupBy(i => i.CreatedDate.Value.ToString("yyyy-MM"))
            .OrderBy(g => g.Key)
            .Select(g => new KeyValuePair<string, decimal>(
                g.Key,
                g.Sum(i => i.SubTotal ?? 0)))
            .ToList();

        return monthlyRevenue;
    }

}
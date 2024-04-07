namespace Travelagency.Infrastructure.Repositories;

public class InvoiceRepository:IInvoiceRepository
{
    private readonly GeneralDbContext _context;

    public InvoiceRepository(GeneralDbContext context)
    {
        _context = context;
    }

    public IUnitOfWork UnitOfWork => _context;

    public void Add(Invoice invoice)
    {
        _context.Invoices.Add(invoice);
    }
    public async Task<Invoice?> GetByIdAsync(Guid invoiceId)
    {
        return await _context.Invoices.FirstOrDefaultAsync(r => r.Id == invoiceId);
    }
}

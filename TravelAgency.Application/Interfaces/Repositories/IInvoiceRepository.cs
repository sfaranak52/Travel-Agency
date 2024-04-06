namespace TravelAgency.Application.Interfaces.Repositories;

public interface IInvoiceRepository: IRepository<Invoice>
{
    void Add(Invoice invoice);
    Task<Invoice?> GetByIdAsync(Guid invoiceId);
}

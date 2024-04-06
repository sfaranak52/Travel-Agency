using TravelAgency.Application.Interfaces.Common;
using TravelAgency.Domain.Aggregates.InvoiceAggregate;

namespace Travelagency.Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly GeneralDbContext _context;

    public CustomerRepository(GeneralDbContext context)
    {
        _context = context;
    }

    public IUnitOfWork UnitOfWork => _context;

    public void Add(Customer customer)
    {
        _context.Customers.Add(customer);
    }
    public async Task<Customer?> GetByIdAsync(Guid customereId)
    {
        return await _context.Customers.FirstOrDefaultAsync(r => r.Id == customereId);
    }
}

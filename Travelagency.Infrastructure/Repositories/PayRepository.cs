using TravelAgency.Application.Interfaces.Common;
using TravelAgency.Domain.Aggregates.InvoiceAggregate;
using TravelAgency.Domain.Aggregates.PayAggregate;

namespace Travelagency.Infrastructure.Repositories;

public class PayRepository:IPayRepository
{
    private readonly GeneralDbContext _context;

    public PayRepository(GeneralDbContext context)
    {
        _context = context;
    }

    public IUnitOfWork UnitOfWork => _context;

    public void Add(Pay pay)
    {
        _context.Pays.Add(pay);
    }

    public async Task<Pay?> GetByIdAsync(Guid payId)
    {
        return await _context.Pays.FirstOrDefaultAsync(p => p.Id == payId);
    }

    public void Remove(Pay pay)
    {
        _context.Remove(pay);
    }
    public void Update(Pay pay)
    {
        _context.Pays.Update(pay);
    }

}

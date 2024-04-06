using TravelAgency.Application.Interfaces.Common;
using TravelAgency.Domain.Aggregates.InvoiceAggregate;
using TravelAgency.Domain.Aggregates.Trip;

namespace Travelagency.Infrastructure.Repositories;

public class TripRepository : ITripRepository
{
    private readonly GeneralDbContext _context;

    public TripRepository(GeneralDbContext context)
    {
        _context = context;
    }

    public IUnitOfWork UnitOfWork => _context;

    public void Add(Trip trip)
    {
        _context.Trips.Add(trip);
    }
    public async Task<Trip?> GetByIdAsync(Guid tripId)
    {
        return await _context.Trips.FirstOrDefaultAsync(r => r.Id == tripId);
    }

    public async Task<decimal> PriceSum(Guid invoiceId)
    {
        var invoiceGroup = await _context.Trips
                                        .Where(trip => trip.InvoiceId == invoiceId)
                                        .GroupBy(trip => trip.InvoiceId)
                                        .FirstOrDefaultAsync();

        
        if (invoiceGroup == null)
        {
            return 0m; // Or throw an exception if no group is expected
        }

        // Extract and return the total price from the group
        return invoiceGroup.Sum(trip => trip.Price);
    }




}

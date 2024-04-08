namespace TravelAgency.Application.Interfaces.Repositories;

public interface ITripRepository:IRepository<Trip>
{
    void Add(Trip trip);
    Task<Trip?> GetByIdAsync(Guid tripId);
    Task<decimal> PriceSum(Guid invoiceId);
}

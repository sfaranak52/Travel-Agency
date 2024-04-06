using TravelAgency.Domain.Aggregates.CutomerAggregate;

namespace TravelAgency.Application.Interfaces.Repositories;

public interface ICustomerRepository: IRepository<Customer>
{
    void Add(Customer customer);
    Task<Customer?> GetByIdAsync(Guid customerId);
}

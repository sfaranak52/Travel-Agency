namespace TravelAgency.Application.Interfaces.Repositories;

public interface IPayRepository:IRepository<Pay>
{
    void Add(Pay pay);
    Task<Pay?> GetByIdAsync(Guid payId);
    void Remove(Pay pay);
    void Update(Pay pay);
}

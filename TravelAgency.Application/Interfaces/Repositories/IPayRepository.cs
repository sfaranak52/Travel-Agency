namespace TravelAgency.Application.Interfaces.Repositories;

public interface IPayRepository:IRepository<Pay>
{
    void Add(Pay pay);
}

namespace TravelAgency.Application.Interfaces.Common;

public interface IRepository<T>
{
    IUnitOfWork UnitOfWork { get; }
}

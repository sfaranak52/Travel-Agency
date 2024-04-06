namespace TravelAgency.Domain.SeedWork;

public interface ICancelationStrategy
{
    decimal CalculateCancelationCost(CancelationTypeEnum cancelationType,decimal price);
}

namespace TravelAgency.Domain.CancelationCostStrategy;

public interface ICancelationStrategy
{
    decimal CalculateCancelationCost(IsCanceledEnum isCancelType, decimal price);
}

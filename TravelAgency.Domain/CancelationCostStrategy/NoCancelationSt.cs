namespace TravelAgency.Domain.CancelationCostStrategy;

public class NoCancelationSt : ICancelationStrategy
{
    public decimal CalculateCancelationCost(IsCanceledEnum isCancelType, decimal price)
    {
        return 0m;
    }
}


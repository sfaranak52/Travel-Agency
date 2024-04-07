namespace TravelAgency.Domain.CancelationCostStrategy;

public class PercentageCancelationSt : ICancelationStrategy
{
    private readonly decimal _percentage;

    public PercentageCancelationSt(decimal percentage)
    {
        _percentage = percentage;
    }

    public decimal CalculateCancelationCost(IsCanceledEnum isCancelType, decimal price)
    {
        if (isCancelType == IsCanceledEnum.Canceled)
        {
            return price * _percentage;
        }
        else
        {
            return price;
        }
    }
}

namespace TravelAgency.Domain.CancelationCost;

public class TransportationStrategy : ICancelationStrategy
{
    public decimal cancellationCost { get; protected set; }
    public decimal CalculateCancelationCost( CancelationTypeEnum cancelationType, decimal price)
    {

        if (cancelationType == CancelationTypeEnum.TransportationTwoHoursBeforeDepart)
        {
            cancellationCost = price * 0.1m;
        }
        else if (cancelationType == CancelationTypeEnum.TransportationAfterDepart)
        {
            cancellationCost = price * 0.5m;
        }
        else if (cancelationType == CancelationTypeEnum.NoCancelation)
        {
            cancellationCost = 0 ;
        }

        return cancellationCost;
    }

}

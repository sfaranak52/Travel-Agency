namespace TravelAgency.Domain.CancelationCost;

public class AirplaneStrategy : ICancelationStrategy
{
    public decimal cancellationCost { get; protected set; }
    public decimal CalculateCancelationCost( CancelationTypeEnum cancelationType, decimal price)
    {

        if (cancelationType == CancelationTypeEnum.AviationNoonThreedaysBeforeDepart)
        {
            cancellationCost = price * 0.3m;
        }
        else if (cancelationType == CancelationTypeEnum.AviationNoonOnedaysBeforeDepart)
        {
            cancellationCost = price * 0.6m;
        }
        else if (cancelationType == CancelationTypeEnum.AviationHalfanHoureBeforeDepart)
        {
            cancellationCost = price * 0.8m;
        }
        else if (cancelationType == CancelationTypeEnum.AviationAfterDepart)
        {
            cancellationCost = price * 0.9m;
        }
        else if (cancelationType == CancelationTypeEnum.NoCancelation)
        {
            cancellationCost = 0;
        }

        return cancellationCost;
    }

}


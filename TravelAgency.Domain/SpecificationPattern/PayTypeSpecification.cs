namespace TravelAgency.Domain.SpecificationPattern;

public class PayTypeSpecification : ISpecification<Pay>
{
    private readonly PayTypeEnum _payType;

    public PayTypeSpecification(PayTypeEnum payType)
    {
        _payType = payType;
    }

    public bool IsSatisfiedBy(Pay pay)
    {
        return pay.PayType == _payType;
    }
}
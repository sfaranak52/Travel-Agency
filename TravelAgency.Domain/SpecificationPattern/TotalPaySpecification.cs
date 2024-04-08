namespace TravelAgency.Domain.SpecificationPattern;

public class TotalPaySpecification : ISumSpecification<Pay>
{
    private readonly DateTime _invoiceDate;

    public TotalPaySpecification(DateTime invoiceDate)
    {
        _invoiceDate = invoiceDate;
    }

    public decimal CalculateSum(IEnumerable<Pay> items)
    {
        var startDate = _invoiceDate.AddDays(-10);
        return items.Where(p => p.PayDate >= startDate).Sum(p => p.Amount);
    }
}

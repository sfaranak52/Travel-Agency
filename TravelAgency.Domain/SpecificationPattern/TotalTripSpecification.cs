namespace TravelAgency.Domain.SpecificationPattern;

public class TotalTripSpecification : ISumSpecification<Trip>
{
    private readonly DateTime _invoiceDate;

    public TotalTripSpecification(DateTime invoiceDate)
    {
        _invoiceDate = invoiceDate;
    }

    public decimal CalculateSum(IEnumerable<Trip> items)
    {
        var startDate = _invoiceDate.AddDays(-10);
        return items.Where(p => p.TripDate >= startDate).Sum(p => p.Price);
    }
}

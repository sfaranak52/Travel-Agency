using TravelAgency.Domain.SpecificationPattern;

namespace TravelAgency.Domain.Aggregates.InvoiceAggregate;

public class Invoice: AggregateRoot<Guid>
{
    public Guid CustomerId { get; protected set; }
    public decimal Expenditures { get; protected set; }
    public DateTime CreateDate { get; protected set; }

    private Invoice(Guid id, Guid customerId, decimal expenditures) : base(id)
    {
        CustomerId = customerId;
        Expenditures = expenditures;
    }

    public static Invoice Create(Guid customerId, decimal expenditures)
    {
        return new Invoice(Guid.NewGuid(), customerId,expenditures);
    }
    public decimal CalculatePayPriceSum(IEnumerable<Pay> pays)
    {
        var date = new TotalPaySpecification(CreateDate);
        return date.CalculateSum(pays);
    }
    public decimal CalculateTripPriceSum(IEnumerable<Trip> trips)
    {
        var date = new TotalTripSpecification(CreateDate);
        return date.CalculateSum(trips);
    }

}

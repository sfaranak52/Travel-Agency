namespace TravelAgency.Domain.Aggregates.Trip;

public class Trip: AggregateRoot<Guid>
{
    public decimal Price { get; protected set; }
    public Guid InvoiceId { get; protected set; }
    public CancelationTypeEnum CancelationType { get; protected set; }
    public string Source { get; protected set; }
    public string Destination { get; protected set; }
    public DateTime DepartTime { get; protected set; }
    public TripTypeEnum TripType { get; protected set; }
    public IsCanceledEnum IsCancelType { get; protected set; }
    public string? Description { get; protected set; }

    private ICancelationStrategy _cancelationStrategy;

    public void SetPenalltyStrategy(ICancelationStrategy cancelationStrategy)
    {
        _cancelationStrategy = cancelationStrategy;
    }

    private decimal CalculateCancelationCost(CancelationTypeEnum cancelationType, decimal price)
    {
        if (_cancelationStrategy == null)
        {
            return price;
        }
        return price - _cancelationStrategy.CalculateCancelationCost(cancelationType, price);
    }

    private Trip(Guid id, decimal price,Guid invoiceId, CancelationTypeEnum cancelationType, string source,
        string destination, DateTime departTime, TripTypeEnum tripType, IsCanceledEnum isCancelType, string description) : base(id)
    {
        Price = price;
        InvoiceId = invoiceId;
        CancelationType = cancelationType;  
        Source = source; 
        Destination = destination;
        DepartTime = departTime; 
        TripType = tripType;
        IsCancelType = isCancelType;
        Description = description;
    }

    public static Trip Create(decimal price,Guid invoiceId, CancelationTypeEnum cancelationType, string source,
        string destination, DateTime departTime, TripTypeEnum tripType, IsCanceledEnum isCancelType, string description)
    {
        var totalPrice = price;
        if (isCancelType == IsCanceledEnum.Canceled)
        {
            totalPrice = price * (decimal)cancelationType / 100;
        }
        return new Trip(Guid.NewGuid(), totalPrice, invoiceId,cancelationType,source,destination,departTime,tripType,isCancelType, description);
    }

}

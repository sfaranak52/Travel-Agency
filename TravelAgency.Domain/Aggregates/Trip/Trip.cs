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

    [NotMapped]
    public ICancelationStrategy CancelationStrategy { get; set; }

    private Trip(Guid id, Guid invoiceId, CancelationTypeEnum cancelationType, string source,
        string destination, DateTime departTime, TripTypeEnum tripType, IsCanceledEnum isCancelType, string description) : base(id)
    {
        InvoiceId = invoiceId;
        CancelationType = cancelationType;  
        Source = source; 
        Destination = destination;
        DepartTime = departTime; 
        TripType = tripType;
        IsCancelType = isCancelType;
        Description = description;
    }

    public static Trip Create(Guid invoiceId, CancelationTypeEnum cancelationType, string source,
        string destination, DateTime departTime, TripTypeEnum tripType, IsCanceledEnum isCancelType, string description)
    {
        return new Trip(Guid.NewGuid(), invoiceId,cancelationType,source,destination,departTime,tripType,isCancelType, description);
    }
    public Trip SetPrice(IsCanceledEnum isCancelType,decimal price)
    {
        Price = CancelationStrategy.CalculateCancelationCost(isCancelType,price);
        return this;
    }
}

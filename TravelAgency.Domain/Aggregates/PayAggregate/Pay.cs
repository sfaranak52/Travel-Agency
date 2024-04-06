namespace TravelAgency.Domain.Aggregates.PayAggregate;
public class Pay : AggregateRoot<Guid>
{
    public Guid InvoiceId { get; protected set; }
    public decimal Amount { get; protected set; }
    public PayTypeEnum PayType { get; protected set; }
    public DateTime PayDate{ get; protected set; }
    public string Description { get; protected set; }

    private Pay(Guid id, Guid invoiceId, decimal amount,PayTypeEnum payType,DateTime payDate,string description) : base(id)
    {
        InvoiceId = invoiceId;
        Amount = amount;
        PayType = payType;
        PayDate = payDate;
        Description = description;
    }

    public static Pay Create(Guid invoiceId, decimal amount, PayTypeEnum payType, string description)
    {
        return new Pay(Guid.NewGuid(), invoiceId, amount, payType, DateTime.Now, description);
    }

}


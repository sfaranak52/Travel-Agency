namespace TravelAgency.Domain.Aggregates.PayAggregate;
public class Pay : AggregateRoot<Guid>
{
    public Guid InvoiceId { get; protected set; }
    public decimal Amount { get; protected set; }
    public PayTypeEnum PayType { get; protected set; }
    public DateTime PayDate{ get; protected set; }
    public string Description { get; protected set; }
    public PayStatusEnum PayStatus { get; protected set; }
    private Pay(Guid id, Guid invoiceId, decimal amount,PayTypeEnum payType,DateTime payDate,PayStatusEnum payStatus,string description) : base(id)
    {
        InvoiceId = invoiceId;
        Amount = amount;
        PayType = payType;
        PayDate = payDate;
        PayStatus = payStatus;
        Description = description;
    }

    public static Pay Create(Guid invoiceId, decimal amount, PayTypeEnum payType,PayStatusEnum payStatus, string description)
    {
        return new Pay(Guid.NewGuid(), invoiceId, amount, payType, DateTime.Now,payStatus, description);
    }

    public Pay SetStatus(PayStatusEnum payStatus)
    {
        PayStatus = payStatus;
        return this;
    }
    public Pay SetDescription(string description)
    {
        Description = description;
        return this;
    }

}


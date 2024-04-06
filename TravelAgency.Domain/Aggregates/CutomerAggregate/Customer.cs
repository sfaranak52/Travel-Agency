namespace TravelAgency.Domain.Aggregates.CutomerAggregate;

public class Customer:AggregateRoot<Guid>
{
    public string Name { get; private set; }
    public string Email { get; private set; }

    public CustomerTypeEnum CustomerType { get; private set; }

    private Customer(Guid id, string name, string email, CustomerTypeEnum customerType) : base(id)
    {
        Name = name;
        Email = email;
        CustomerType = customerType;
    }

    public static Customer Create(string name, string email, CustomerTypeEnum customerType)
    {
        return new Customer(Guid.NewGuid(), name, email, customerType);
    }
}

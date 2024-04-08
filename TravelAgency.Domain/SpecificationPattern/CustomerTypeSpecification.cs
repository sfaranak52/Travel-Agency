namespace TravelAgency.Domain.SpecificationPattern;

public class CustomerTypeSpecification : ISpecification<Customer>
{
    private readonly CustomerTypeEnum _customerType;

    public CustomerTypeSpecification(CustomerTypeEnum customerType)
    {
        _customerType = customerType;
    }

    public bool IsSatisfiedBy(Customer customer)
    {
        return customer.CustomerType == _customerType;
    }
}
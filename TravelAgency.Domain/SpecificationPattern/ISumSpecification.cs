namespace TravelAgency.Domain.SpecificationPattern;

public interface ISumSpecification<T>
{
    decimal CalculateSum(IEnumerable<T> items);
}

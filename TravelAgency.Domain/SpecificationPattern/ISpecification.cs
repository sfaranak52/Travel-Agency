namespace TravelAgency.Domain.SpecificationPattern;

public interface ISpecification<T>
{
    bool IsSatisfiedBy(T entity);
}

namespace TravelAgency.Application.Features.Customer.Command.AddCustomer;

public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, Guid>
{
    private readonly ICustomerRepository _customerRepository;

    public AddCustomerCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Guid> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = Domain.Aggregates.CutomerAggregate.Customer.Create(request.Name, request.Email,request.CustomerTypeEnum);

        _customerRepository.Add(customer);
        await _customerRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        return customer.Id;
    }
}

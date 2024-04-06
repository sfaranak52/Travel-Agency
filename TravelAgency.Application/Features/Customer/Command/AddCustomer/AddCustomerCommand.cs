using TravelAgency.Domain.Enum;

namespace TravelAgency.Application.Features.Customer.Command.AddCustomer;

public record AddCustomerCommand(string Name,string Email,CustomerTypeEnum CustomerTypeEnum) : IRequest<Guid>;

namespace TravelAgency.Application.Features.Pay.Command.DeletePay;

public record DeletePayCommand(Guid PayId, string Description) : IRequest<Guid>;

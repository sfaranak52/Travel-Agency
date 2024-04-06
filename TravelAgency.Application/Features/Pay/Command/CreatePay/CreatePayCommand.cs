namespace TravelAgency.Application.Features.Pay.Command.CreatePay;

public record CreatePayCommand(Guid InvoiceId, PayTypeEnum PayType,decimal Amount,string Description) : IRequest<Guid>;

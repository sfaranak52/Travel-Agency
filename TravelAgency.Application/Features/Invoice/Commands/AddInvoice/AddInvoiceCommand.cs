namespace TravelAgency.Application.Features.Invoice.Commands.AddInvoice;

public record AddInvoiceCommand(Guid CustomerId,decimal Expenditures) : IRequest<Guid>;
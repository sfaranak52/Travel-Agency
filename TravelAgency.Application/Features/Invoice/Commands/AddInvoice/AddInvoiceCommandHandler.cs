using TravelAgency.Domain.SpecificationPattern;

namespace TravelAgency.Application.Features.Invoice.Commands.AddInvoice;

public class AddInvoiceCommandHandler : IRequestHandler<AddInvoiceCommand, Guid>
{
    private readonly IInvoiceRepository _invoiceRepository;
    //public ISumSpecification<Domain.Aggregates.PayAggregate.Pay> _TotalPaySpecification;
    //public ISumSpecification<Domain.Aggregates.TripAggregate.Trip> _TotalTripSpecification;

    public AddInvoiceCommandHandler(IInvoiceRepository invoiceRepository)
    {
        _invoiceRepository = invoiceRepository;
    }

    public async Task<Guid> Handle(AddInvoiceCommand request, CancellationToken cancellationToken)
    {
        var invoice = Domain.Aggregates.InvoiceAggregate.Invoice.Create(request.CustomerId, request.Expenditures);

        _invoiceRepository.Add(invoice);
        await _invoiceRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        return invoice.Id;
    }

    //public Invoice SetExpenditures(decimal expenditures)
    //{
    //    var price = _TotalTripSpecification.CalculateSum();
    //    Expenditures = price;
    //    return this;
    //}
}

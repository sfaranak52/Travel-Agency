namespace TravelAgency.Application.Features.Pay.Command.CreatePay;

public class CreatePayCommandHandler : IRequestHandler<CreatePayCommand, Guid>
{
    private readonly IInvoiceRepository  _invoiceRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly ITripRepository _tripRepository;
    private readonly IPayRepository _payRepository;

    public CreatePayCommandHandler(IInvoiceRepository invoiceRepository,ICustomerRepository customerRepository
                                  ,ITripRepository tripRepository, IPayRepository payRepository)
    {
        _invoiceRepository = invoiceRepository;
        _customerRepository = customerRepository;
        _tripRepository = tripRepository;
        _payRepository = payRepository;
    }

    public async Task<Guid> Handle(CreatePayCommand request, CancellationToken cancellationToken)
    {
        var invoice = await _invoiceRepository.GetByIdAsync(request.InvoiceId);
        var customer = await _customerRepository.GetByIdAsync(invoice.CustomerId);
        var tripPrice = await _tripRepository.PriceSum(request.InvoiceId);
        if ((customer.CustomerType == CustomerTypeEnum.Cash && request.PayType == PayTypeEnum.Cash &&
             tripPrice - request.Amount > 0) || customer.CustomerType == CustomerTypeEnum.Credit && request.PayType == PayTypeEnum.Credit &&
             tripPrice > request.Amount * 0.5m)
        {
            var pay = Domain.Aggregates.PayAggregate.Pay.Create(request.InvoiceId, request.Amount, request.PayType, PayStatusEnum.Paied, request.Description);
            _payRepository.Add(pay);
            await _payRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return pay.Id;
        }
        else
        {
            throw new InvalidOperationException("You are unable to pay");
        }
    }
}

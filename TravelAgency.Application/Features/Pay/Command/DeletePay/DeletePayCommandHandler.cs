namespace TravelAgency.Application.Features.Pay.Command.DeletePay;

public class DeletePayCommandHandler : IRequestHandler<DeletePayCommand, Guid>
{
    private readonly IPayRepository _payRepository;

    public DeletePayCommandHandler(IPayRepository payRepository)
    {
        _payRepository = payRepository;
    }

    public async Task<Guid> Handle(DeletePayCommand request, CancellationToken cancellationToken)
    {
        var payment = await _payRepository.GetByIdAsync(request.PayId);

        if (payment == null)
        {
            throw new Exception("payment is not valid");
        }

        payment.SetStatus(PayStatusEnum.Deleted).SetDescription(request.Description);

        _payRepository.Update(payment);
        await _payRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        return request.PayId;
    }
}
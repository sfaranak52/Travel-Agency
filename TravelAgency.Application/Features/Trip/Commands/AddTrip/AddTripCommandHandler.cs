using TravelAgency.Application.Interfaces.Repositories;

namespace TravelAgency.Application.Features.Trip.Commands.AddTrip;

public class AddTripCommandHandler : IRequestHandler<AddTripCommand, Guid>
{
    private readonly ITripRepository _tripRepository;

    public AddTripCommandHandler(ITripRepository tripRepository)
    {
        _tripRepository = tripRepository;
    }

    public async Task<Guid> Handle(AddTripCommand request, CancellationToken cancellationToken)
    {
        var trip = Domain.Aggregates.Trip.Trip.Create(request.Price,request.Invoiceid,request.CancelationType,request.Source,request.Destination
                                                     ,request.DepartTime,request.Triptype,request.IsCancelType,request.Description);
        _tripRepository.Add(trip);
        await _tripRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        return trip.Id;
    }
}

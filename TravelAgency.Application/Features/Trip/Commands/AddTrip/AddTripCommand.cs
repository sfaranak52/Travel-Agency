namespace TravelAgency.Application.Features.Trip.Commands.AddTrip;

public record AddTripCommand(Guid Invoiceid, decimal Price, CancelationTypeEnum CancelationType, string Source, string Destination
                , DateTime DepartTime, TripTypeEnum Triptype, IsCanceledEnum IsCancelType, string Description) : IRequest<Guid>;

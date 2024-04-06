namespace TravelAgency.Api.Dtos;

public record AddTripDto(Guid Invoiceid, decimal Price, CancelationTypeEnum CancelationType, string Source, string Destination
                , DateTime DepartTime, TripTypeEnum Triptype, IsCanceledEnum IsCancelType, string Description);

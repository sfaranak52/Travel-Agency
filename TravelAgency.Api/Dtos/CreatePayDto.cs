namespace TravelAgency.Api.Dtos;

public record CreatePayDto(Guid InvoiceId, PayTypeEnum PayType, decimal Amount, string Description);


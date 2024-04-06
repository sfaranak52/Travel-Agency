using TravelAgency.Domain.Enum;

namespace TravelAgency.Api.Dtos;

public record AddCustomerDto(string Name,string Email,CustomerTypeEnum CustomerType);
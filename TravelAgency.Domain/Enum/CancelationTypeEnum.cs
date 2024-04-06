namespace TravelAgency.Domain.Enum;

public enum CancelationTypeEnum
{
    AviationNoonThreedaysBeforeDepart = 30,
    AviationNoonOnedaysBeforeDepart = 60,
    AviationHalfanHoureBeforeDepart = 80,
    AviationAfterDepart = 90,
    TransportationTwoHoursBeforeDepart = 10,
    TransportationAfterDepart = 50,
    NoCancelation = 1
}

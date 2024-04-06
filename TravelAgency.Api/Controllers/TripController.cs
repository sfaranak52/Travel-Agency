

using TravelAgency.Application.Features.Trip.Commands.AddTrip;

namespace TravelAgency.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TripController : ControllerBase
{
    private readonly IMediator _mediator;
    public TripController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Add Trip
    /// </summary>
    /// <param name = "request" ></ param >
    /// < returns > trip Data</returns>

    [HttpPost]
    public async Task<IActionResult> AddTrip(AddTripDto request)
    {

        var command = new AddTripCommand(request.Invoiceid,request.Price,request.CancelationType
            ,request.Source,request.Destination,request.DepartTime,request.Triptype,request.IsCancelType,request.Description);

        var result = await _mediator.Send(command);
        return Ok(result);

    }
}

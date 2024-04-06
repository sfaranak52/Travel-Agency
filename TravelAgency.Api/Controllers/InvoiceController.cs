

using TravelAgency.Application.Features.Trip.Commands.AddTrip;

namespace TravelAgency.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InvoiceController : ControllerBase
{
    private readonly IMediator _mediator;
    public InvoiceController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Add Invoice
    /// </summary>
    /// <param name = "request" ></ param >
    /// < returns > Invice Data</returns>
    [HttpPost]
    public async Task<IActionResult> AddInvoice(AddInvoiceDto request)
    {

        var command = new AddInvoiceCommand(request.CustomerId,request.Expenditures);

        var result = await _mediator.Send(command);
        return Ok(result);

    }


}

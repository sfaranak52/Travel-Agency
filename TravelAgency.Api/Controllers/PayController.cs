using TravelAgency.Application.Features.Pay.Command.CreatePay;

namespace TravelAgency.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PayController : ControllerBase
{
    private readonly IMediator _mediator;
    public PayController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Create Peyment
    /// </summary>
    /// <param name = "request" ></ param >
    /// < returns > Peyment Data</returns>

    [HttpPost]
    public async Task<IActionResult> CreatePay(CreatePayDto request)
    {
        var command = new CreatePayCommand(request.InvoiceId,request.PayType,request.Amount,request.Description);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}

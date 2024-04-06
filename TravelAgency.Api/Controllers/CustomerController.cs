using TravelAgency.Application.Features.Customer.Command.AddCustomer;

namespace TravelAgency.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly IMediator _mediator;
    public CustomerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Add Customer
    /// </summary>
    /// <param name = "request" ></ param >
    /// < returns > Customer Information</returns>
    [HttpPost]
    public async Task<IActionResult> AddCustomer(AddCustomerDto request)
    {

        var command = new AddCustomerCommand(request.Name,request.Email,request.CustomerType);

        var result = await _mediator.Send(command);
        return Ok(result);

    }
}

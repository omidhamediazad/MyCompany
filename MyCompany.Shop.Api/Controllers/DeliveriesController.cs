using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCompany.Shop.Application.Features.Orders.Commands;

[ApiController]
[Route("api/deliveries")]
public class DeliveriesController : ControllerBase
{
    private readonly IMediator _mediator;
    public DeliveriesController(IMediator mediator) => _mediator = mediator;

    [HttpPost("{orderId:guid}/send")]
    public async Task<IActionResult> Send(Guid orderId)
    {
        var result = await _mediator.Send(new SendDeliveryCommand(orderId));
        return result is null ? BadRequest() : Ok(result);
    }
}

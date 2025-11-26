using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCompany.Shop.Application.DTOs;
using MyCompany.Shop.Application.Features.Orders.Commands;

[ApiController]
[Route("api/payments")]
public class PaymentsController : ControllerBase
{
    private readonly IMediator _mediator;
    public PaymentsController(IMediator mediator) => _mediator = mediator;

    [HttpPost("{orderId:guid}/init")]
    public async Task<IActionResult> Init(Guid orderId)
    {
        var result = await _mediator.Send(new InitPaymentCommand(orderId));
        return Ok(result); // contains gateway URL
    }

    [HttpPost("{orderId:guid}/verify")]
    public async Task<IActionResult> Verify(Guid orderId, [FromBody] VerifyPaymentRequest request)
    {
        var ok = await _mediator.Send(new VerifyPaymentCommand(orderId, request));
        return ok ? Ok() : BadRequest();
    }
}

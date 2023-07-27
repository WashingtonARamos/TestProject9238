using Application.UseCases.Liquid.Models;
using Application.UseCases.RecordStructToObject.Models;
using DotLiquid.Util;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SerilogTimings;

namespace WebAPI.Controllers;

[Route("v1/[controller]")]
[Controller]
public class SampleController : ControllerBase
{
    private readonly IMediator _mediator;

    public SampleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> Liquid([FromQuery] string clientId, CancellationToken cancellationToken)
    {
        using (Operation.Time("Timings for operation:"))
        {
            var result = await _mediator.Send(new LiquidInput()
            {
                ClientId = clientId
            }, cancellationToken);

            return Ok(result.Body);
        }
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> RecordStructToObject([FromQuery] string clientId, CancellationToken cancellationToken)
    {
        using (Operation.Time("Timings for operation:"))
        {
            var result = await _mediator.Send(new RecordStructToObjectInput()
            {
                ClientId = clientId
            }, cancellationToken);

            return Ok(result.Body);
        }
    }
}
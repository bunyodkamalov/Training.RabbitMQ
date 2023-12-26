using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Training.RabbitMQ.Application.Common.Identity.Models;
using Training.RabbitMQ.Application.Common.Identity.Services;

namespace Training.RabbitMQ.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IMapper mapper, IAuthAggregationService authAggregationService) : ControllerBase
{
    [HttpPost("sign-up")]
    public async ValueTask<IActionResult> SignUp([FromBody] SignUpDetails signUpDetails, CancellationToken cancellationToken)
    {
        var result = await authAggregationService.SignUpAsync(signUpDetails, cancellationToken);
        return result ? Ok() : BadRequest();
    }
}
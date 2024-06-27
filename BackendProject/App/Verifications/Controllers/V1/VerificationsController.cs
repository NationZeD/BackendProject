using Asp.Versioning;
using BackendProject.App.Verifications.Commands.SendVerificationCode;
using BackendProject.Shared;
using BackendProject.Shared.Persistence.Data;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BackendProject.App.Verifications.Controllers.V1;

[ApiController] 
[EnableCors(ProjectEnvironment.DefaultPolicy)]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]/[action]")]
public class VerificationsController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> SendVerificationCode([FromBody] SendVerificationCodeRequest request)
    {
        await mediator.Send(new SendVerificationCodeCommand(request));
        return Ok(ServiceResponse.SucceededInstance());
    }
}
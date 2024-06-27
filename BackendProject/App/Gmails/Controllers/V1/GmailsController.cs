using Asp.Versioning;
using BackendProject.App.Gmails.Commands.Send;
using BackendProject.Shared;
using BackendProject.Shared.Persistence.Data;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BackendProject.App.Gmails.Controllers.V1;

[ApiController]
[EnableCors(ProjectEnvironment.DefaultPolicy)]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]/[action]")]
public class GmailsController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> SendGmail([FromBody] SendGmailRequest request)
    {
        await mediator.Send(new SendGmailCommand(request));
        return Ok(ServiceResponse.SucceededInstance());
    }
}
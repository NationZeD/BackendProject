using Asp.Versioning;
using BackendProject.App.Accounts.Customers.Commands.SignIn;
using BackendProject.App.Accounts.Employees.BaseEmployee.Commands.SignIn;
using BackendProject.Shared;
using BackendProject.Shared.Persistence.Data;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BackendProject.App.Auth.Controllers.V1;

[EnableCors(ProjectEnvironment.DefaultPolicy)]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]/[action]")]
[ApiController]
public class AuthController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CustomerSignIn([FromBody] SignInCustomerRequest request)
    {
        var command = new SignInCustomerCommand(request);
        return Ok(ServiceResponse.SucceededInstance(await mediator.Send(command)));
    }
    
    [HttpPost]
    public async Task<IActionResult> EmployeeSignIn([FromBody] SignInRequest request)
    {
        var command = new SignInCommand(request);
        return Ok(ServiceResponse.SucceededInstance(await mediator.Send(command)));
    }

    [HttpPost]
    public async Task<IActionResult> OAuthSignin([FromHeader] SignInRequest request)
    {
        var result = await mediator.Send(new SignInCommand(request));
        if (!string.IsNullOrEmpty(result.AccessToken))
        {
            return Ok(new
            {
                type = "Bearer",
                expires_in = 86400,
                access_token = result.AccessToken
            });
        }

        return BadRequest("Invalid user parameters");
    }
}
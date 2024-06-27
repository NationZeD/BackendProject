using Asp.Versioning;
using BackendProject.App.Accounts.Customers.Commands.SignUp;
using BackendProject.App.Accounts.Customers.Queries.Get;
using BackendProject.App.Accounts.Customers.Queries.GetByUserName;
using BackendProject.App.Auth.Constants;
using BackendProject.Shared;
using BackendProject.Shared.Persistence.Data;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BackendProject.App.Accounts.Customers.Controllers.V1;

[EnableCors(ProjectEnvironment.DefaultPolicy)]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]/[action]")]
[ApiController]
public class CustomersController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> SignUp([FromBody] SignUpCustomerRequest request)
    {
        var command = new SignUpCustomerCommand(request);
        await mediator.Send(command);
        return Ok(ServiceResponse.SucceededInstance());
    }

    [Authorize(Roles = $"{Roles.Customer},{Roles.Admin}")]
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var result = await mediator.Send(new GetCustomerQuery(id));
        return Ok(ServiceResponse.SucceededInstance(result));
    }

    [Authorize(Roles = $"{Roles.Customer},{Roles.Admin}")]
    [HttpGet("{username}")]
    public async Task<IActionResult> GetByUserName(string username)
    {
        var result = await mediator.Send(new GetCustomerByUserNameQuery(username));
        return Ok(ServiceResponse.SucceededInstance(result));
    }
}
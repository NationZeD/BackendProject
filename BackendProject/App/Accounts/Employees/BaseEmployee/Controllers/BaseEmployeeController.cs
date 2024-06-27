using BackendProject.App.Accounts.Employees.BaseEmployee.Abstractions;
using BackendProject.App.Accounts.Employees.BaseEmployee.Entities;
using BackendProject.Shared;
using BackendProject.Shared.Abstractions;
using BackendProject.Shared.Persistence.Data;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BackendProject.App.Accounts.Employees.BaseEmployee.Controllers;

[Route("api/v{version:apiVersion}/[controller]/[action]")]
[ApiController]
[EnableCors(ProjectEnvironment.DefaultPolicy)]
public abstract class BaseEmployeeController<TEntity, TEntityId, TDto, TCreateRequest, TUpdateRequest> : ControllerBase
    where TEntity : BaseEmployee<TEntityId>
    where TEntityId : BaseEntityId
    where TCreateRequest : ICreateEmployeeRequest<TEntity, TEntityId>
{
    protected readonly IMediator _mediator;

    protected BaseEmployeeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public virtual async Task<IActionResult> Create([FromBody] TCreateRequest request)
    {
        await GenerateCreateAsync(request);
        return Ok(ServiceResponse.SucceededInstance());
    }

    [HttpPost]
    public async Task<IActionResult> Update([FromBody] TUpdateRequest request)
    {
        await GenerateUpdateAsync(request);
        return Ok(ServiceResponse.SucceededInstance());
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await GenerateDeleteAsync(id);
        return Ok(ServiceResponse.SucceededInstance());
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> Get(Guid id)
    {
        var entity = await GenerateGetAsync(id);
        return Ok(ServiceResponse.SucceededInstance(entity));
    }

    [HttpGet("{username}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetByUserName(string username)
    {
        var entity = await GenerateGetByUserNameAsync(username);
        return Ok(ServiceResponse.SucceededInstance(entity));
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAll()
    {
        var entities = await GenerateGetAllAsync();
        return Ok(ServiceResponse.SucceededInstance(entities));
    }

    protected abstract Task GenerateCreateAsync(TCreateRequest request);
    protected abstract Task GenerateUpdateAsync(TUpdateRequest request);
    protected abstract Task GenerateDeleteAsync(Guid id);
    protected abstract Task<TDto> GenerateGetAsync(Guid id);
    protected abstract Task<TDto> GenerateGetByUserNameAsync(string username);
    protected abstract Task<List<TDto>> GenerateGetAllAsync();
}
using BackendProject.App.Auth.Constants;
using BackendProject.App.Multilinguals.Dtos;
using BackendProject.Shared.Persistence.Data;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BackendProject.Shared.Abstractions.LanguagedCRUD;

[Route("api/v{version:apiVersion}/[controller]/[action]")]
[ApiController]
[EnableCors(ProjectEnvironment.DefaultPolicy)]
[Authorize(Roles = Roles.Admin)]
public abstract class BaseLanguagedCrudController<TEntity, TEntityId, TForm, TDto>(IMediator mediator) : ControllerBase
    where TEntity : BaseEntity<TEntityId>
    where TEntityId : BaseEntityId
    where TForm : IForm<TEntity>
{
    protected readonly IMediator _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TForm form)
    {
        await GenerateCreateAsync(form);
        return Ok(ServiceResponse.SucceededInstance());
    }

    [HttpPost]
    public async Task<IActionResult> Update([FromBody] TForm form)
    {
        await GenerateUpdateAsync(form);
        return Ok(ServiceResponse.SucceededInstance());
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await GenerateDeleteAsync(id);
        return Ok(ServiceResponse.SucceededInstance());
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> Get([FromQuery] BaseLanguagedQuery query)
    {
        var result = await GenerateGetAsync(query.Id, query.Lang);
        return Ok(ServiceResponse.SucceededInstance(result));
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> Get(Guid id)
    {
        var result = await GenerateGetAsync(id);
        return Ok(ServiceResponse.SucceededInstance(result));
    }

    [HttpGet("{lang}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetAll(string lang)
    {
        var result = await GenerateGetAllAsync(lang);
        return Ok(ServiceResponse.SucceededInstance(result));
    }

    [HttpGet]
    public async Task<IActionResult> GetForm()
    {
        var result = await GenerateForm();
        return Ok(ServiceResponse.SucceededInstance(result));
    }

    protected abstract Task<TForm> GenerateForm();
    protected abstract Task<List<TDto>> GenerateGetAllAsync(string lang);
    protected abstract Task<TDto> GenerateGetAsync(Guid id, string lang);
    protected abstract Task<TForm> GenerateGetAsync(Guid id);
    protected abstract Task GenerateDeleteAsync(Guid id);
    protected abstract Task GenerateUpdateAsync(TForm dto);
    protected abstract Task GenerateCreateAsync(TForm dto);
}
using BackendProject.Shared.Persistence.Data;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BackendProject.Shared.Abstractions.CRUD;

[Route("api/v{version:apiVersion}/[controller]/[action]")]
[ApiController]
[EnableCors(ProjectEnvironment.DefaultPolicy)]
[Authorize(Roles = "Admin")]
public abstract class BaseCrudController<TEntity, TEntityId, TDto> : ControllerBase
    where TEntity : BaseEntity<TEntityId> where TEntityId : BaseEntityId where TDto : ICrudDTO<TEntity>
{
    protected readonly IMediator _mediator;

    protected BaseCrudController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public virtual async Task<IActionResult> Create([FromBody] TDto dto)
    {
        await GenerateCreateAsync(dto);
        return Ok(ServiceResponse.SucceededInstance());
    }

    [HttpPost]
    public async Task<IActionResult> Update([FromBody] TDto dto)
    {
        await GenerateUpdateAsync(dto);
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

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAll()
    {
        var entities = await GenerateGetAllAsync();
        return Ok(ServiceResponse.SucceededInstance(entities));
    }

    protected abstract Task<List<TDto>> GenerateGetAllAsync();
    protected abstract Task<TDto> GenerateGetAsync(Guid id);
    protected abstract Task GenerateDeleteAsync(Guid id);
    protected abstract Task GenerateUpdateAsync(TDto dto);
    protected abstract Task GenerateCreateAsync(TDto dto);
}
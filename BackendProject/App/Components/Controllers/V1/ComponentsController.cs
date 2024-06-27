using Asp.Versioning;
using BackendProject.App.Components.Commands.Create;
using BackendProject.App.Components.Commands.Delete;
using BackendProject.App.Components.Commands.Edit;
using BackendProject.App.Components.Dtos;
using BackendProject.App.Components.Entities;
using BackendProject.App.Components.Queries.Get;
using BackendProject.App.Components.Queries.GetAll;
using BackendProject.App.Components.Queries.GetByLang;
using BackendProject.App.Components.Queries.GetForm;
using BackendProject.App.Components.ValueObjects;
using BackendProject.Shared.Abstractions.LanguagedCRUD;
using MediatR;

namespace BackendProject.App.Components.Controllers.V1;

[ApiVersion("1.0")]
public class ComponentsController(IMediator mediator)
    : BaseLanguagedCrudController<Component, ComponentId, ComponentForm, ComponentDto>(mediator)
{
    protected override async Task GenerateCreateAsync(ComponentForm form)
    {
        await _mediator.Send(new CreateComponentCommand(form));
    }

    protected override async Task GenerateUpdateAsync(ComponentForm form)
    {
        await _mediator.Send(new EditComponentCommand(form));
    }

    protected override async Task GenerateDeleteAsync(Guid id)
    {
        await _mediator.Send(new DeleteComponentCommand(new ComponentId(id)));
    }

    protected override async Task<ComponentForm> GenerateGetAsync(Guid id)
    {
        return await _mediator.Send(new GetComponentQuery(id));
    }

    protected override async Task<ComponentDto> GenerateGetAsync(Guid id, string lang)
    {
        return await _mediator.Send(new GetComponentByLangQuery(id, lang));
    }

    protected override async Task<List<ComponentDto>> GenerateGetAllAsync(string lang)
    {
        return await _mediator.Send(new GetAllComponentsQuery(lang));
    }

    protected override async Task<ComponentForm> GenerateForm()
    {
        return await _mediator.Send(new GetComponentFormQuery());
    }
}
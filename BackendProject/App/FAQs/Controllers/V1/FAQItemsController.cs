using Asp.Versioning;
using BackendProject.App.FAQs.Commands.Create;
using BackendProject.App.FAQs.Commands.Delete;
using BackendProject.App.FAQs.Commands.Edit;
using BackendProject.App.FAQs.Dtos;
using BackendProject.App.FAQs.Entities;
using BackendProject.App.FAQs.Queries.Get;
using BackendProject.App.FAQs.Queries.GetAll;
using BackendProject.App.FAQs.Queries.GetByLang;
using BackendProject.App.FAQs.Queries.GetForm;
using BackendProject.App.FAQs.ValueObjects;
using BackendProject.Shared.Abstractions.LanguagedCRUD;
using MediatR;

namespace BackendProject.App.FAQs.Controllers.V1;

[ApiVersion("1.0")]
public class FAQItemsController(IMediator mediator)
    : BaseLanguagedCrudController<FAQItem, FAQItemId, FAQItemForm, FAQItemDto>(mediator)
{
    protected override async Task GenerateCreateAsync(FAQItemForm form) 
    {
        await _mediator.Send(new CreateFAQItemCommand(form));
    }
    
    protected override async Task GenerateUpdateAsync(FAQItemForm form)
    {
        await _mediator.Send(new EditFAQItemCommand(form));
    }

    protected override async Task GenerateDeleteAsync(Guid id)
    {
        await _mediator.Send(new DeleteFAQItemCommand(new FAQItemId(id)));
    }

    protected override async Task<FAQItemForm> GenerateGetAsync(Guid id)
    {
        return await _mediator.Send(new GetFAQItemQuery(id));
    }

    protected override async Task<FAQItemDto> GenerateGetAsync(Guid id, string lang)
    {
        return await _mediator.Send(new GetFAQItemByLangQuery(id, lang));
    }

    protected override async Task<List<FAQItemDto>> GenerateGetAllAsync(string lang)
    {
        return await _mediator.Send(new GetAllFAQItemsQuery(lang));
    }

    protected override async Task<FAQItemForm> GenerateForm()
    {
        return await _mediator.Send(new GetFAQItemFormQuery());
    }
}
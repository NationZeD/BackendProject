using Asp.Versioning;
using BackendProject.App.Categories.Commands.Create;
using BackendProject.App.Categories.Commands.Delete;
using BackendProject.App.Categories.Commands.Edit;
using BackendProject.App.Categories.Dtos;
using BackendProject.App.Categories.Entities;
using BackendProject.App.Categories.Queries.Get;
using BackendProject.App.Categories.Queries.GetAll;
using BackendProject.App.Categories.Queries.GetByLang;
using BackendProject.App.Categories.Queries.GetForm;
using BackendProject.App.Categories.ValueObjects;
using BackendProject.Shared.Abstractions.LanguagedCRUD;
using MediatR;

namespace BackendProject.App.Categories.Controllers.V1;

[ApiVersion("1.0")]
public class CategoryController(IMediator mediator)
    : BaseLanguagedCrudController<Category, CategoryId, CategoryForm, CategoryDto>(mediator)
{
    protected override async Task<CategoryForm> GenerateForm()
    {
        return await _mediator.Send(new GetCategoryFormQuery());
    }

    protected override async Task<List<CategoryDto>> GenerateGetAllAsync(string lang)
    {
        return await _mediator.Send(new GetAllCategoriesQuery(lang));
    }

    protected override async Task<CategoryDto> GenerateGetAsync(Guid id, string lang)
    {
        return await _mediator.Send(new GetCategoryByLangQuery(id, lang));
    }

    protected override async Task<CategoryForm> GenerateGetAsync(Guid id)
    {
        return await _mediator.Send(new GetCategoryQuery(id));
    }

    protected override async Task GenerateDeleteAsync(Guid id)
    {
        await _mediator.Send(new DeleteCategoryCommand(new CategoryId(id)));
    }

    protected override async Task GenerateUpdateAsync(CategoryForm form)
    {
        await _mediator.Send(new EditCategoryCommand(form));
    }

    protected override async Task GenerateCreateAsync(CategoryForm form)
    {
        await _mediator.Send(new CreateCategoryCommand(form));
    }
}
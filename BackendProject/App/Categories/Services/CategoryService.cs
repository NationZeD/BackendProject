using BackendProject.App.Categories.Dtos;
using BackendProject.App.Categories.Entities;
using BackendProject.App.Categories.Repositories.IRepositories;
using BackendProject.App.Categories.Services.IServices;
using BackendProject.App.Categories.ValueObjects;
using BackendProject.App.Multilinguals.Entities;
using BackendProject.Shared.Abstractions.LanguagedCRUD;

namespace BackendProject.App.Categories.Services;

public class CategoryService(ICategoryRepository repository, ILanguagedReadRepository<CategoryDto> readRepository)
    : LanguagedCrudService<Category, CategoryId, CategoryForm, CategoryDto>
        (repository, readRepository), ICategoryService
{
    public override CategoryForm GetForm()
    {
        return CategoryForm.GetNewInstance();
    }

    public override async Task<CategoryForm> GetAsync(CategoryId id)
    {
        var entity = await repository.GetAsync(id);
        if (entity is null)
            throw new Exception("No records were found with given parameters");
        var form = CategoryForm.GetNewInstance();
        form.Read(entity);
        return form;
    }

    protected override async Task<Category> GenerateEntityAsync(CategoryForm form)
    {
        if (form.Id is not null)
            return await repository.GetAsync(new CategoryId(form.Id.Value));

        var entity = Category.Create(Multilingual.GetNewInstance());
        return entity;
    }
}
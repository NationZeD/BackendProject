using BackendProject.App.Components.Dtos;
using BackendProject.App.Components.Entities;
using BackendProject.App.Components.Repositories.IRepositories;
using BackendProject.App.Components.Services.IServices;
using BackendProject.App.Components.ValueObjects;
using BackendProject.App.Multilinguals.Entities;
using BackendProject.Shared.Abstractions.LanguagedCRUD;

namespace BackendProject.App.Components.Services;

public class ComponentService(IComponentRepository repository, IComponentReadRepository readRepository)
    : LanguagedCrudService<Component, ComponentId, ComponentForm, ComponentDto>(repository,
        readRepository), IComponentService
{
    public override ComponentForm GetForm()
    {
        return ComponentForm.GetNewInstance();
    }

    protected override async Task<Component> GenerateEntityAsync(ComponentForm form)
    {
        if (form.Id is not null)
            return await repository.GetAsync(new ComponentId(form.Id.Value));
        
        var entity = Component.Create(Multilingual.GetNewInstance(), form.Code);
        return entity;
    }
}
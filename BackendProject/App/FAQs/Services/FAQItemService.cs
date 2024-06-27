using BackendProject.App.FAQs.Dtos;
using BackendProject.App.FAQs.Entities;
using BackendProject.App.FAQs.Repositories.IRepositories;
using BackendProject.App.FAQs.Services.IService;
using BackendProject.App.FAQs.ValueObjects;
using BackendProject.App.Multilinguals.Entities;
using BackendProject.Shared.Abstractions.LanguagedCRUD;

namespace BackendProject.App.FAQs.Services;

public class FAQItemService(IFAQItemRepository repository, IFAQItemReadRepository readRepository)
    : LanguagedCrudService<FAQItem, FAQItemId, FAQItemForm, FAQItemDto>(repository,
        readRepository), IFAQItemService
{
    public override FAQItemForm GetForm()
    {
        return FAQItemForm.GetNewInstance();
    }

    protected override async Task<FAQItem> GenerateEntityAsync(FAQItemForm form)
    {
        if (form.Id is not null)
            return await repository.GetAsync(new FAQItemId(form.Id.Value));
        
        var entity = FAQItem.Create(Multilingual.GetNewInstance(), Multilingual.GetNewInstance());
        return entity;
    }
}
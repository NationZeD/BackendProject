using BackendProject.App.FAQs.Dtos;
using BackendProject.App.FAQs.Entities;
using BackendProject.App.FAQs.Services.IService;
using BackendProject.App.FAQs.ValueObjects;
using BackendProject.Shared.Abstractions.LanguagedCRUD.Queries.Get;

namespace BackendProject.App.FAQs.Queries.Get;

public class GetFAQItemQueryHandler(IFAQItemService languagedCrudService)
    : BaseLanguagedGetQueryHandler<FAQItem, FAQItemId, FAQItemForm, FAQItemDto, GetFAQItemQuery>(languagedCrudService);
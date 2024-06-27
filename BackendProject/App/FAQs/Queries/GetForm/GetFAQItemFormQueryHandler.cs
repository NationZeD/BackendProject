using BackendProject.App.FAQs.Dtos;
using BackendProject.App.FAQs.Entities;
using BackendProject.App.FAQs.Services.IService;
using BackendProject.App.FAQs.ValueObjects;
using BackendProject.Shared.Abstractions.LanguagedCRUD.Queries.GetForm;

namespace BackendProject.App.FAQs.Queries.GetForm;

public class GetFAQItemFormQueryHandler(IFAQItemService languagedCrudService) : BaseLanguagedGetFormQueryHandler
    <FAQItem, FAQItemId, FAQItemForm, FAQItemDto, GetFAQItemFormQuery>(languagedCrudService);
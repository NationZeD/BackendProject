using BackendProject.App.FAQs.Dtos;
using BackendProject.App.FAQs.Entities;
using BackendProject.App.FAQs.ValueObjects;
using BackendProject.Shared.Abstractions.LanguagedCRUD;

namespace BackendProject.App.FAQs.Services.IService;

public interface IFAQItemService : ILanguagedCrudService<FAQItem, FAQItemId, FAQItemForm, FAQItemDto>;
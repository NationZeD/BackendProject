using BackendProject.App.FAQs.Dtos;
using BackendProject.App.FAQs.Entities;
using BackendProject.App.FAQs.Services.IService;
using BackendProject.App.FAQs.ValueObjects;
using BackendProject.Shared.Abstractions;
using BackendProject.Shared.Abstractions.LanguagedCRUD.Commands.Create;

namespace BackendProject.App.FAQs.Commands.Create;

public class CreateFAQItemCommandHandler(IFAQItemService service, IUnitOfWork unitOfWork)
    : BaseLanguagedCreateCommandHandler<FAQItem, FAQItemId, FAQItemForm, FAQItemDto
        , CreateFAQItemCommand>(service, unitOfWork);
using BackendProject.App.FAQs.Dtos;
using BackendProject.App.FAQs.Entities;
using BackendProject.App.FAQs.Services.IService;
using BackendProject.App.FAQs.ValueObjects;
using BackendProject.Shared.Abstractions;
using BackendProject.Shared.Abstractions.LanguagedCRUD.Commands.Edit;

namespace BackendProject.App.FAQs.Commands.Edit;

public class EditFAQItemCommandHandler(IFAQItemService service, IUnitOfWork unitOfWork)
    : BaseLanguagedEditCommandHandler
        <FAQItem, FAQItemId, FAQItemForm, FAQItemDto, EditFAQItemCommand>(service, unitOfWork);
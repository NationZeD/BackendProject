using BackendProject.App.FAQs.Dtos;
using BackendProject.App.FAQs.Entities;
using BackendProject.App.FAQs.Services.IService;
using BackendProject.App.FAQs.ValueObjects;
using BackendProject.Shared.Abstractions;
using BackendProject.Shared.Abstractions.LanguagedCRUD.Commands.Delete;

namespace BackendProject.App.FAQs.Commands.Delete;

public class DeleteFAQItemCommandHandler(IFAQItemService service, IUnitOfWork unitOfWork)
    : BaseLanguagedDeleteCommandHandler
        <FAQItem, FAQItemId, FAQItemForm, FAQItemDto, DeleteFAQItemCommand>(service, unitOfWork);
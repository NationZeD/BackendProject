using BackendProject.App.FAQs.Dtos;
using BackendProject.App.FAQs.Entities;
using BackendProject.App.FAQs.ValueObjects;
using BackendProject.Shared.Abstractions.LanguagedCRUD.Commands.Delete;

namespace BackendProject.App.FAQs.Commands.Delete;

public class DeleteFAQItemCommand(FAQItemId id)
    : BaseLanguagedDeleteCommand<FAQItem, FAQItemId, FAQItemForm, FAQItemDto>(id);
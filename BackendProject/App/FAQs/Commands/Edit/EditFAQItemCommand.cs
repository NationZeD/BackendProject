using BackendProject.App.FAQs.Dtos;
using BackendProject.App.FAQs.Entities;
using BackendProject.App.FAQs.ValueObjects;
using BackendProject.Shared.Abstractions.LanguagedCRUD.Commands.Edit;

namespace BackendProject.App.FAQs.Commands.Edit;

public class EditFAQItemCommand(FAQItemForm request)
    : BaseLanguagedEditCommand<FAQItem, FAQItemId, FAQItemForm, FAQItemDto>(request);
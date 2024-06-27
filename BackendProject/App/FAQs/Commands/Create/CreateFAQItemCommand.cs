using BackendProject.App.FAQs.Dtos;
using BackendProject.App.FAQs.Entities;
using BackendProject.App.FAQs.ValueObjects;
using BackendProject.Shared.Abstractions.LanguagedCRUD.Commands.Create;

namespace BackendProject.App.FAQs.Commands.Create;

public class CreateFAQItemCommand(FAQItemForm request)
    : BaseLanguagedCreateCommand<FAQItem, FAQItemId, FAQItemForm, FAQItemDto>(request);
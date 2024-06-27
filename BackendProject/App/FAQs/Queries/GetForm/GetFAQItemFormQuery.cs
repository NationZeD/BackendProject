using BackendProject.App.FAQs.Dtos;
using BackendProject.App.FAQs.Entities;
using BackendProject.Shared.Abstractions.LanguagedCRUD.Queries.GetForm;

namespace BackendProject.App.FAQs.Queries.GetForm;

public class GetFAQItemFormQuery : BaseLanguagedGetFormQuery<FAQItem, FAQItemForm>;
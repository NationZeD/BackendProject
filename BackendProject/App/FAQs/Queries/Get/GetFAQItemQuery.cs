using BackendProject.App.FAQs.Dtos;
using BackendProject.App.FAQs.Entities;
using BackendProject.Shared.Abstractions.LanguagedCRUD.Queries.Get;

namespace BackendProject.App.FAQs.Queries.Get;

public class GetFAQItemQuery(Guid id) : BaseLanguagedGetQuery<FAQItem, FAQItemForm>(id);
using BackendProject.App.FAQs.Dtos;
using BackendProject.App.FAQs.Entities;
using BackendProject.App.FAQs.Repositories.IRepositories;
using BackendProject.App.FAQs.ValueObjects;
using BackendProject.Shared.Abstractions.LanguagedCRUD.Queries.GetByLang;

namespace BackendProject.App.FAQs.Queries.GetByLang;

public class GetFAQItemByLangQueryHandler(IFAQItemReadRepository repo)
    : BaseLanguagedGetByLangQueryHandler<FAQItem, FAQItemId, FAQItemDto, GetFAQItemByLangQuery>(repo);
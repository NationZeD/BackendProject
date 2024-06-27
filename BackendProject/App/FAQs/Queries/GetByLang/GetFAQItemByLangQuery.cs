using BackendProject.App.FAQs.Dtos;
using BackendProject.App.FAQs.Entities;
using BackendProject.Shared.Abstractions.LanguagedCRUD.Queries.GetByLang;

namespace BackendProject.App.FAQs.Queries.GetByLang;

public class GetFAQItemByLangQuery(Guid id, string lang) : BaseLanguagedGetByLangQuery<FAQItem, FAQItemDto>(id, lang);
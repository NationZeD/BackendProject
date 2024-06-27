using BackendProject.App.FAQs.Dtos;
using BackendProject.App.FAQs.Entities;
using BackendProject.Shared.Abstractions.LanguagedCRUD.Queries.GetAll;

namespace BackendProject.App.FAQs.Queries.GetAll;

public class GetAllFAQItemsQuery(string lang) : BaseLanguagedGetAllQuery<FAQItem, FAQItemDto>(lang);
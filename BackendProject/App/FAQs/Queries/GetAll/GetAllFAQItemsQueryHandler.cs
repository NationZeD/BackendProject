using BackendProject.App.FAQs.Dtos;
using BackendProject.App.FAQs.Entities;
using BackendProject.App.FAQs.Repositories.IRepositories;
using BackendProject.App.FAQs.ValueObjects;
using BackendProject.Shared.Abstractions.LanguagedCRUD.Queries.GetAll;

namespace BackendProject.App.FAQs.Queries.GetAll;

public class GetAllFAQItemsQueryHandler(IFAQItemReadRepository repo)
    : BaseLanguagedGetAllQueryHandler<FAQItem, FAQItemId, FAQItemDto, GetAllFAQItemsQuery>(repo);
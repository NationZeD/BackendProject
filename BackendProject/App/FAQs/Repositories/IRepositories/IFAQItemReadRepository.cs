using BackendProject.App.FAQs.Dtos;
using BackendProject.Shared.Abstractions.LanguagedCRUD;

namespace BackendProject.App.FAQs.Repositories.IRepositories;

public interface IFAQItemReadRepository : ILanguagedReadRepository<FAQItemDto>;
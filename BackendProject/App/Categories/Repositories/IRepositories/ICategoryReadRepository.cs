using BackendProject.App.Categories.Dtos;
using BackendProject.Shared.Abstractions.LanguagedCRUD;

namespace BackendProject.App.Categories.Repositories.IRepositories;

public interface ICategoryReadRepository : ILanguagedReadRepository<CategoryDto>;
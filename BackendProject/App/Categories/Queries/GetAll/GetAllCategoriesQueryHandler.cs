using BackendProject.App.Categories.Dtos;
using BackendProject.App.Categories.Entities;
using BackendProject.App.Categories.Repositories.IRepositories;
using BackendProject.App.Categories.ValueObjects;
using BackendProject.Shared.Abstractions.LanguagedCRUD.Queries.GetAll;

namespace BackendProject.App.Categories.Queries.GetAll;

public class GetAllCategoriesQueryHandler(ICategoryReadRepository repo)
    : BaseLanguagedGetAllQueryHandler<Category, CategoryId, CategoryDto, GetAllCategoriesQuery>(repo);
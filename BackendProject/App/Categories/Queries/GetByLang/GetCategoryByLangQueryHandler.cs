using BackendProject.App.Categories.Dtos;
using BackendProject.App.Categories.Entities;
using BackendProject.App.Categories.Repositories.IRepositories;
using BackendProject.App.Categories.ValueObjects;
using BackendProject.Shared.Abstractions.LanguagedCRUD.Queries.GetByLang;

namespace BackendProject.App.Categories.Queries.GetByLang;

public class GetCategoryByLangQueryHandler(ICategoryReadRepository repo) : BaseLanguagedGetByLangQueryHandler
    <Category, CategoryId, CategoryDto, GetCategoryByLangQuery>(repo);
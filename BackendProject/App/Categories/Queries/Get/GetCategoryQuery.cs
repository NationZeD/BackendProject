using BackendProject.App.Categories.Dtos;
using BackendProject.App.Categories.Entities;
using BackendProject.Shared.Abstractions.LanguagedCRUD.Queries.Get;

namespace BackendProject.App.Categories.Queries.Get;

public class GetCategoryQuery(Guid id) : BaseLanguagedGetQuery<Category, CategoryForm>(id);
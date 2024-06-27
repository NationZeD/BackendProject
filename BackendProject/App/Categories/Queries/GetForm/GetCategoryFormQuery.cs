using BackendProject.App.Categories.Dtos;
using BackendProject.App.Categories.Entities;
using BackendProject.Shared.Abstractions.LanguagedCRUD.Queries.GetForm;

namespace BackendProject.App.Categories.Queries.GetForm;

public class GetCategoryFormQuery : BaseLanguagedGetFormQuery<Category, CategoryForm>;
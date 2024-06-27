using BackendProject.App.Categories.Dtos;
using BackendProject.App.Categories.Entities;
using BackendProject.App.Categories.Services.IServices;
using BackendProject.App.Categories.ValueObjects;
using BackendProject.Shared.Abstractions.LanguagedCRUD.Queries.Get;

namespace BackendProject.App.Categories.Queries.Get;

public class GetCategoryQueryHandler(ICategoryService languagedCrudService) : BaseLanguagedGetQueryHandler
    <Category, CategoryId, CategoryForm, CategoryDto, GetCategoryQuery>(languagedCrudService);
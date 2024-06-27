using BackendProject.App.Categories.Dtos;
using BackendProject.App.Categories.Entities;
using BackendProject.App.Categories.Services.IServices;
using BackendProject.App.Categories.ValueObjects;
using BackendProject.Shared.Abstractions.LanguagedCRUD.Queries.GetForm;

namespace BackendProject.App.Categories.Queries.GetForm;

public class GetCategoryFormQueryHandler(ICategoryService languagedCrudService) : BaseLanguagedGetFormQueryHandler
    <Category, CategoryId, CategoryForm, CategoryDto, GetCategoryFormQuery>(languagedCrudService);
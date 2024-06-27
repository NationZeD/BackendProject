using BackendProject.App.Categories.Dtos;
using BackendProject.App.Categories.Entities;
using BackendProject.Shared.Abstractions.LanguagedCRUD.Queries.GetAll;

namespace BackendProject.App.Categories.Queries.GetAll;

public class GetAllCategoriesQuery(string lang) : BaseLanguagedGetAllQuery<Category, CategoryDto>(lang);
using BackendProject.App.Categories.Dtos;
using BackendProject.App.Categories.Entities;
using BackendProject.Shared.Abstractions.LanguagedCRUD.Queries.GetByLang;

namespace BackendProject.App.Categories.Queries.GetByLang;

public class GetCategoryByLangQuery(Guid id, string lang)
    : BaseLanguagedGetByLangQuery<Category, CategoryDto>(id, lang);
using BackendProject.App.Categories.Dtos;
using BackendProject.App.Categories.Entities;
using BackendProject.App.Categories.ValueObjects;
using BackendProject.Shared.Abstractions.LanguagedCRUD.Commands.Create;

namespace BackendProject.App.Categories.Commands.Create;

public class CreateCategoryCommand(CategoryForm request)
    : BaseLanguagedCreateCommand<Category, CategoryId, CategoryForm, CategoryDto>(request);
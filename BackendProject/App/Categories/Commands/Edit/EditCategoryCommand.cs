using BackendProject.App.Categories.Dtos;
using BackendProject.App.Categories.Entities;
using BackendProject.App.Categories.ValueObjects;
using BackendProject.Shared.Abstractions.LanguagedCRUD.Commands.Edit;

namespace BackendProject.App.Categories.Commands.Edit;

public class EditCategoryCommand(CategoryForm request)
    : BaseLanguagedEditCommand<Category, CategoryId, CategoryForm, CategoryDto>(request);
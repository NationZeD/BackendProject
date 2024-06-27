using BackendProject.App.Categories.Dtos;
using BackendProject.App.Categories.Entities;
using BackendProject.App.Categories.ValueObjects;
using BackendProject.Shared.Abstractions.LanguagedCRUD.Commands.Delete;

namespace BackendProject.App.Categories.Commands.Delete;

public class DeleteCategoryCommand(CategoryId id)
    : BaseLanguagedDeleteCommand<Category, CategoryId, CategoryForm, CategoryDto>(id);
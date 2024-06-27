using BackendProject.App.Categories.Dtos;
using BackendProject.App.Categories.Entities;
using BackendProject.App.Categories.Services.IServices;
using BackendProject.App.Categories.ValueObjects;
using BackendProject.Shared.Abstractions;
using BackendProject.Shared.Abstractions.LanguagedCRUD.Commands.Delete;

namespace BackendProject.App.Categories.Commands.Delete;

public class DeleteCategoryCommandHandler(ICategoryService service, IUnitOfWork unitOfWork)
    : BaseLanguagedDeleteCommandHandler<Category, CategoryId, CategoryForm, CategoryDto, DeleteCategoryCommand>
        (service, unitOfWork);
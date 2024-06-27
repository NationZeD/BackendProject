using BackendProject.App.Categories.Dtos;
using BackendProject.App.Categories.Entities;
using BackendProject.App.Categories.Services.IServices;
using BackendProject.App.Categories.ValueObjects;
using BackendProject.Shared.Abstractions;
using BackendProject.Shared.Abstractions.LanguagedCRUD.Commands.Create;

namespace BackendProject.App.Categories.Commands.Create;

public class CreateCategoryCommandHandler(ICategoryService service, IUnitOfWork unitOfWork)
    : BaseLanguagedCreateCommandHandler<Category, CategoryId, CategoryForm, CategoryDto, CreateCategoryCommand>
        (service, unitOfWork);
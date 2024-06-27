using BackendProject.App.Categories.Dtos;
using BackendProject.App.Categories.Entities;
using BackendProject.App.Categories.ValueObjects;
using BackendProject.Shared.Abstractions.LanguagedCRUD;

namespace BackendProject.App.Categories.Services.IServices;

public interface ICategoryService : ILanguagedCrudService<Category, CategoryId, CategoryForm, CategoryDto>;
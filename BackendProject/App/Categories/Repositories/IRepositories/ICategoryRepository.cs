using BackendProject.App.Categories.Entities;
using BackendProject.App.Categories.ValueObjects;
using BackendProject.Shared.Abstractions;

namespace BackendProject.App.Categories.Repositories.IRepositories;

public interface ICategoryRepository : IBaseRepository<Category, CategoryId>;
using BackendProject.Shared.Abstractions;

namespace BackendProject.App.Accounts.Employees.BaseEmployee.Repositories.IRepositories;

public interface IBaseEmployeeReadRepository<TDto> : IRepository
{
    Task<TDto> GetAsync(Guid id);
    Task<TDto> GetByUserNameAsync(string username);
    Task<List<TDto>> GetAllAsync();
}
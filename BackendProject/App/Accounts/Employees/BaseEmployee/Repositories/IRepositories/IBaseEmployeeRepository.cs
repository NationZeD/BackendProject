using BackendProject.App.Accounts.Employees.BaseEmployee.Entities;
using BackendProject.Shared.Abstractions;

namespace BackendProject.App.Accounts.Employees.BaseEmployee.Repositories.IRepositories;

public interface IBaseEmployeeRepository<TBaseEmployee, TId> : IBaseRepository<TBaseEmployee, TId>
    where TBaseEmployee : BaseEmployee<TId> where TId : BaseEntityId
{
    Task<bool> ExistsAsync(string username);
    Task<TBaseEmployee> GetAsync(string username);
}
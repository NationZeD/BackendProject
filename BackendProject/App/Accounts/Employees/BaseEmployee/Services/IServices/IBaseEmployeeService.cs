using BackendProject.App.Accounts.Employees.BaseEmployee.Abstractions;
using BackendProject.App.Accounts.Employees.BaseEmployee.Entities;
using BackendProject.Shared.Abstractions;

namespace BackendProject.App.Accounts.Employees.BaseEmployee.Services.IServices;

public interface IBaseEmployeeService<TBaseEmployee, TId> : IAppService
    where TBaseEmployee : BaseEmployee<TId>
    where TId: BaseEntityId
{
    Task<bool> ExistsAsync(string username);
    Task<TId> CreateAsync(ICreateEmployeeRequest<TBaseEmployee,TId> request);
    Task UpdateAsync(IUpdateEmployeeRequest<TBaseEmployee, TId> request);
    Task DeleteAsync(TId id);
}
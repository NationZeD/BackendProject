using BackendProject.App.Accounts.Employees.BaseEmployee.Entities;
using BackendProject.Shared.Abstractions;

namespace BackendProject.App.Accounts.Employees.BaseEmployee.Abstractions;

public interface ICreateEmployeeRequest<TEmployee, TId> where TEmployee: BaseEmployee<TId> where TId : BaseEntityId
{
    public string UserName { get; set; }
    public string Password { get; set; }
    void Write(TEmployee employee);
}
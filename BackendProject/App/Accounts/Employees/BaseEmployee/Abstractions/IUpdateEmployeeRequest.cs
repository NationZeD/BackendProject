using BackendProject.App.Accounts.Employees.BaseEmployee.Entities;
using BackendProject.Shared.Abstractions;

namespace BackendProject.App.Accounts.Employees.BaseEmployee.Abstractions;

public interface IUpdateEmployeeRequest<TEmployee, TId> where TEmployee: BaseEmployee<TId> where TId : BaseEntityId
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    void Write(TEmployee employee);
}
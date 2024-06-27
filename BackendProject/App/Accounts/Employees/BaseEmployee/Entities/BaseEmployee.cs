using BackendProject.Shared.Abstractions;

namespace BackendProject.App.Accounts.Employees.BaseEmployee.Entities;

public abstract class BaseEmployee<TId> : BaseAccount<TId> where TId : BaseEntityId
{
    public string UserName { get; set; }

    public BaseEmployee()
    {
        
    }
    public BaseEmployee(TId id) : base(id)
    {
    }

    protected BaseEmployee(TId id, string userName, string firstName, string lastName) : base(id, firstName, lastName)
    {
        UserName = userName;
    }
}
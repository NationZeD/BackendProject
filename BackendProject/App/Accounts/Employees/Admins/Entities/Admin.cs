using BackendProject.App.Accounts.Employees.Admins.ValueObjects;
using BackendProject.App.Accounts.Employees.BaseEmployee.Entities;

namespace BackendProject.App.Accounts.Employees.Admins.Entities;

public class Admin : BaseEmployee<AdminId>
{
    public Admin() : base(new AdminId(Guid.NewGuid()))
    {
    }

    private Admin(AdminId id,string userName, string firstName,
        string lastName) : base(id, userName, firstName, lastName)
    {
    }
    
    public static Admin Create(AdminId id, string userName, string firstName, string lastName)
    {
        return new Admin(id, userName, firstName, lastName);
    }
}
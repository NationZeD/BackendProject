using BackendProject.App.Accounts.Employees.Admins.Entities;
using BackendProject.App.Accounts.Employees.Admins.ValueObjects;
using BackendProject.App.Accounts.Employees.BaseEmployee.Abstractions;

namespace BackendProject.App.Accounts.Employees.Admins.Commands.Edit;

public class UpdateAdminRequest : IUpdateEmployeeRequest<Admin, AdminId>
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public void Write(Admin employee)
    {
        employee.UserName = UserName;
        employee.FirstName = FirstName;
        employee.LastName = LastName;
    }
}
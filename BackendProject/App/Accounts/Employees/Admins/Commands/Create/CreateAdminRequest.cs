using BackendProject.App.Accounts.Employees.Admins.Entities;
using BackendProject.App.Accounts.Employees.Admins.ValueObjects;
using BackendProject.App.Accounts.Employees.BaseEmployee.Abstractions;

namespace BackendProject.App.Accounts.Employees.Admins.Commands.Create;

public class CreateAdminRequest : ICreateEmployeeRequest<Admin, AdminId>
{
    public string UserName { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
    
    public void Write(Admin employee)
    {
        employee.UserName = UserName;
        employee.FirstName = FirstName;
        employee.LastName = LastName;
    }
}
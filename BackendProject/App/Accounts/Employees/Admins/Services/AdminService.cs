using BackendProject.App.Accounts.Employees.Admins.Entities;
using BackendProject.App.Accounts.Employees.Admins.Repositories.IRepositories;
using BackendProject.App.Accounts.Employees.Admins.Services.IServices;
using BackendProject.App.Accounts.Employees.Admins.ValueObjects;
using BackendProject.App.Accounts.Employees.BaseEmployee.Abstractions;
using BackendProject.App.Accounts.Employees.BaseEmployee.Services;

namespace BackendProject.App.Accounts.Employees.Admins.Services;

public class AdminService(IAdminRepository repository)
    : BaseEmployeeService<Admin, AdminId, IAdminRepository>(repository), IAdminService
{
    protected override Admin GenerateEmployee(ICreateEmployeeRequest<Admin, AdminId> request)
    {
        return new Admin
        {
            FirstName = null,
            LastName = null,
            UserName = null
        };
    }
}
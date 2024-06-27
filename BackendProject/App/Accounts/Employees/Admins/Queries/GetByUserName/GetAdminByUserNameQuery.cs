using BackendProject.App.Accounts.Employees.Admins.Dtos;
using BackendProject.App.Accounts.Employees.Admins.Entities;
using BackendProject.App.Accounts.Employees.BaseEmployee.Queries.GetByUsername;

namespace BackendProject.App.Accounts.Employees.Admins.Queries.GetByUserName;

public class GetAdminByUserNameQuery : BaseEmployeeGetByUserNameQuery<Admin, AdminDto>
{
    public GetAdminByUserNameQuery(string username) : base(username)
    {
    }
}
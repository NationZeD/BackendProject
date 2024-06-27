using BackendProject.App.Accounts.Employees.Admins.Dtos;
using BackendProject.App.Accounts.Employees.Admins.Entities;
using BackendProject.App.Accounts.Employees.BaseEmployee.Queries.Get;

namespace BackendProject.App.Accounts.Employees.Admins.Queries.Get;

public class GetAdminQuery : BaseEmployeeGetQuery<Admin, AdminDto>
{
    public GetAdminQuery(Guid id) : base(id)
    {
    }
}
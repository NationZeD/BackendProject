using BackendProject.App.Accounts.Employees.Admins.Dtos;
using BackendProject.App.Accounts.Employees.Admins.Entities;
using BackendProject.App.Accounts.Employees.Admins.Repositories.IRepositories;
using BackendProject.App.Accounts.Employees.Admins.ValueObjects;
using BackendProject.App.Accounts.Employees.BaseEmployee.Queries.Get;

namespace BackendProject.App.Accounts.Employees.Admins.Queries.Get;

public class GetAdminQueryHandler : BaseEmployeeGetQueryHandler<Admin, AdminId, AdminDto, GetAdminQuery>
{
    public GetAdminQueryHandler(IAdminReadRepository repository) : base(repository)
    {
    }
}
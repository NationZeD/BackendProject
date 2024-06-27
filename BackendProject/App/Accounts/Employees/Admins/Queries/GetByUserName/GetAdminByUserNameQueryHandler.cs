using BackendProject.App.Accounts.Employees.Admins.Dtos;
using BackendProject.App.Accounts.Employees.Admins.Entities;
using BackendProject.App.Accounts.Employees.Admins.Repositories.IRepositories;
using BackendProject.App.Accounts.Employees.Admins.ValueObjects;
using BackendProject.App.Accounts.Employees.BaseEmployee.Queries.GetByUsername;

namespace BackendProject.App.Accounts.Employees.Admins.Queries.GetByUserName;

public class GetAdminByUserNameQueryHandler : BaseEmployeeGetByUsernameQueryHandler
    <Admin, AdminId, AdminDto, GetAdminByUserNameQuery>
{
    public GetAdminByUserNameQueryHandler(IAdminReadRepository repository) : base(repository)
    {
    }
}
using BackendProject.App.Accounts.Employees.Admins.Dtos;
using BackendProject.App.Accounts.Employees.Admins.Entities;
using BackendProject.App.Accounts.Employees.Admins.Repositories.IRepositories;
using BackendProject.App.Accounts.Employees.Admins.ValueObjects;
using BackendProject.App.Accounts.Employees.BaseEmployee.Queries.GetAll;

namespace BackendProject.App.Accounts.Employees.Admins.Queries.GetAll;

public class GetAllAdminsQueryHandler : BaseEmployeeGetAllQueryHandler<Admin, AdminId, AdminDto, GetAllAdminsQuery>
{
    public GetAllAdminsQueryHandler(IAdminReadRepository repo) : base(repo)
    {
    }
}
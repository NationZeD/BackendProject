using BackendProject.App.Accounts.Employees.Admins.Dtos;
using BackendProject.App.Accounts.Employees.Admins.Entities;
using BackendProject.App.Accounts.Employees.BaseEmployee.Queries.GetAll;

namespace BackendProject.App.Accounts.Employees.Admins.Queries.GetAll;

public class GetAllAdminsQuery : BaseEmployeeGetAllQuery<Admin, AdminDto>;
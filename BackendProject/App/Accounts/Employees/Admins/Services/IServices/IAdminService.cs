using BackendProject.App.Accounts.Employees.Admins.Entities;
using BackendProject.App.Accounts.Employees.Admins.ValueObjects;
using BackendProject.App.Accounts.Employees.BaseEmployee.Services.IServices;

namespace BackendProject.App.Accounts.Employees.Admins.Services.IServices;

public interface IAdminService : IBaseEmployeeService<Admin, AdminId>;
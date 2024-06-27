using BackendProject.App.Accounts.Employees.Admins.Entities;
using BackendProject.App.Accounts.Employees.Admins.ValueObjects;
using BackendProject.App.Accounts.Employees.BaseEmployee.Repositories.IRepositories;

namespace BackendProject.App.Accounts.Employees.Admins.Repositories.IRepositories;

public interface IAdminRepository : IBaseEmployeeRepository<Admin,AdminId>;
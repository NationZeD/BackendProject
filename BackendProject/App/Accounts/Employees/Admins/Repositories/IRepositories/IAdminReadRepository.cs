using BackendProject.App.Accounts.Employees.Admins.Dtos;
using BackendProject.App.Accounts.Employees.BaseEmployee.Repositories.IRepositories;

namespace BackendProject.App.Accounts.Employees.Admins.Repositories.IRepositories;

public interface IAdminReadRepository : IBaseEmployeeReadRepository<AdminDto>;
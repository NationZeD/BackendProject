using BackendProject.App.Accounts.Employees.Admins.Entities;
using BackendProject.App.Accounts.Employees.Admins.Repositories.IRepositories;
using BackendProject.App.Accounts.Employees.Admins.ValueObjects;
using BackendProject.App.Accounts.Employees.BaseEmployee.Repositories;
using BackendProject.Shared.Persistence.Data;

namespace BackendProject.App.Accounts.Employees.Admins.Repositories;

public class AdminRepository(ApplicationDbContext db) : BaseEmployeeRepository<Admin, AdminId>(db), IAdminRepository;
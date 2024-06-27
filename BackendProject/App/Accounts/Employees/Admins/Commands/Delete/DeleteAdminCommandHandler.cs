using BackendProject.App.Accounts.Employees.Admins.Entities;
using BackendProject.App.Accounts.Employees.Admins.Services.IServices;
using BackendProject.App.Accounts.Employees.Admins.ValueObjects;
using BackendProject.App.Accounts.Employees.BaseEmployee.Commands.Delete;
using BackendProject.App.Auth.Services.IServices;
using BackendProject.Shared.Abstractions;

namespace BackendProject.App.Accounts.Employees.Admins.Commands.Delete;

public class DeleteAdminCommandHandler(IAdminService service, IUserService userService, IUnitOfWork unitOfWork)
    : DeleteBaseEmployeeCommandHandler<DeleteAdminCommand,AdminId , Admin>(service, userService, unitOfWork);
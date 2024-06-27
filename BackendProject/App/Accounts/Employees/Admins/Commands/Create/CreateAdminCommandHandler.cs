using BackendProject.App.Accounts.Employees.Admins.Entities;
using BackendProject.App.Accounts.Employees.Admins.Services.IServices;
using BackendProject.App.Accounts.Employees.Admins.ValueObjects;
using BackendProject.App.Accounts.Employees.BaseEmployee.Commands.Create;
using BackendProject.App.Auth.Constants;
using BackendProject.App.Auth.Services.IServices;
using BackendProject.Shared.Abstractions;

namespace BackendProject.App.Accounts.Employees.Admins.Commands.Create;

public class CreateAdminCommandHandler(IAdminService service, IUserService userService, IUnitOfWork unitOfWork)
    : CreateBaseEmployeeCommandHandler<CreateAdminCommand, CreateAdminRequest, AdminId, Admin>(service, userService,
        unitOfWork, Roles.Admin);
using BackendProject.App.Accounts.Employees.Admins.Entities;
using BackendProject.App.Accounts.Employees.Admins.Services.IServices;
using BackendProject.App.Accounts.Employees.Admins.ValueObjects;
using BackendProject.App.Accounts.Employees.BaseEmployee.Commands.Edit;
using BackendProject.App.Auth.Services.IServices;
using BackendProject.Shared.Abstractions;

namespace BackendProject.App.Accounts.Employees.Admins.Commands.Edit;

public class UpdateAdminCommandHandler(IAdminService service, IUserService userService, IUnitOfWork unitOfWork)
    : UpdateBaseEmployeeCommandHandler<UpdateAdminCommand, UpdateAdminRequest, AdminId, Admin>
    (service, unitOfWork, userService);
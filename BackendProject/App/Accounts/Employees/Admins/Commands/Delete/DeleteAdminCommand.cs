using BackendProject.App.Accounts.Employees.Admins.ValueObjects;
using BackendProject.App.Accounts.Employees.BaseEmployee.Commands.Delete;

namespace BackendProject.App.Accounts.Employees.Admins.Commands.Delete;

public record DeleteAdminCommand(AdminId Id)
    : DeleteBaseEmployeeCommand<AdminId>(Id);
using BackendProject.App.Accounts.Employees.BaseEmployee.Commands.Edit;

namespace BackendProject.App.Accounts.Employees.Admins.Commands.Edit;

public record UpdateAdminCommand(UpdateAdminRequest Request)
    : UpdateBaseEmployeeCommand<UpdateAdminRequest>(Request);
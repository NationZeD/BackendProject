using BackendProject.App.Accounts.Employees.BaseEmployee.Commands.Create;

namespace BackendProject.App.Accounts.Employees.Admins.Commands.Create;

public class CreateAdminCommand(CreateAdminRequest request)
    : CreateBaseEmployeeCommand<CreateAdminRequest>(request);

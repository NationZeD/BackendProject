using BackendProject.App.Accounts.Employees.BaseEmployee.Commands.Create;

namespace BackendProject.App.Accounts.Employees.Lecturers.Commands.Create;

public class CreateLecturerCommand(CreateLecturerRequest request)
    : CreateBaseEmployeeCommand<CreateLecturerRequest>(request);
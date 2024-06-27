using BackendProject.App.Accounts.Employees.BaseEmployee.Commands.Edit;

namespace BackendProject.App.Accounts.Employees.Lecturers.Commands.Edit;

public record UpdateLecturerCommand(UpdateLecturerRequest Request)
    : UpdateBaseEmployeeCommand<UpdateLecturerRequest>(Request);
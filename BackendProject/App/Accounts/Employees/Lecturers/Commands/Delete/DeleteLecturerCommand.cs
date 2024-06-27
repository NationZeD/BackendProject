using BackendProject.App.Accounts.Employees.BaseEmployee.Commands.Delete;
using BackendProject.App.Accounts.Employees.Lecturers.ValueObjects;

namespace BackendProject.App.Accounts.Employees.Lecturers.Commands.Delete;

public record DeleteLecturerCommand(LecturerId Id)
    : DeleteBaseEmployeeCommand<LecturerId>(Id);
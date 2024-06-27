using BackendProject.App.Accounts.Employees.BaseEmployee.Commands.Create;
using BackendProject.App.Accounts.Employees.Lecturers.Entities;
using BackendProject.App.Accounts.Employees.Lecturers.Services.IServices;
using BackendProject.App.Accounts.Employees.Lecturers.ValueObjects;
using BackendProject.App.Auth.Constants;
using BackendProject.App.Auth.Services.IServices;
using BackendProject.Shared.Abstractions;

namespace BackendProject.App.Accounts.Employees.Lecturers.Commands.Create;

public class CreateLecturerCommandHandler(ILecturerService service, IUserService userService, IUnitOfWork unitOfWork)
    : CreateBaseEmployeeCommandHandler<CreateLecturerCommand, CreateLecturerRequest, LecturerId, Lecturer>
    (service, userService, unitOfWork, Roles.Admin);
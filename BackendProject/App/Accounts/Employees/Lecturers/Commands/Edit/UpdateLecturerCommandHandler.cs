using BackendProject.App.Accounts.Employees.BaseEmployee.Commands.Edit;
using BackendProject.App.Accounts.Employees.Lecturers.Entities;
using BackendProject.App.Accounts.Employees.Lecturers.Services.IServices;
using BackendProject.App.Accounts.Employees.Lecturers.ValueObjects;
using BackendProject.App.Auth.Services.IServices;
using BackendProject.Shared.Abstractions;

namespace BackendProject.App.Accounts.Employees.Lecturers.Commands.Edit;

public class UpdateLecturerCommandHandler(ILecturerService service, IUserService userService, IUnitOfWork unitOfWork)
    : UpdateBaseEmployeeCommandHandler<UpdateLecturerCommand, UpdateLecturerRequest, LecturerId, Lecturer>
        (service, unitOfWork, userService);
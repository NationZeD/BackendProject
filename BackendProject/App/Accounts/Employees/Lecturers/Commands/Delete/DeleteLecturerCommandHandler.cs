using BackendProject.App.Accounts.Employees.BaseEmployee.Commands.Delete;
using BackendProject.App.Accounts.Employees.Lecturers.Entities;
using BackendProject.App.Accounts.Employees.Lecturers.Services.IServices;
using BackendProject.App.Accounts.Employees.Lecturers.ValueObjects;
using BackendProject.App.Auth.Services.IServices;
using BackendProject.Shared.Abstractions;

namespace BackendProject.App.Accounts.Employees.Lecturers.Commands.Delete;

public class DeleteLecturerCommandHandler(ILecturerService service, IUserService userService, IUnitOfWork unitOfWork)
    : DeleteBaseEmployeeCommandHandler<DeleteLecturerCommand, LecturerId, Lecturer>(service, userService, unitOfWork);
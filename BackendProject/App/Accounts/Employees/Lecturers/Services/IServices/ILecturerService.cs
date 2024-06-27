using BackendProject.App.Accounts.Employees.BaseEmployee.Services.IServices;
using BackendProject.App.Accounts.Employees.Lecturers.Entities;
using BackendProject.App.Accounts.Employees.Lecturers.ValueObjects;

namespace BackendProject.App.Accounts.Employees.Lecturers.Services.IServices;

public interface ILecturerService : IBaseEmployeeService<Lecturer, LecturerId>;
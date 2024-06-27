using BackendProject.App.Accounts.Employees.BaseEmployee.Repositories.IRepositories;
using BackendProject.App.Accounts.Employees.Lecturers.Entities;
using BackendProject.App.Accounts.Employees.Lecturers.ValueObjects;

namespace BackendProject.App.Accounts.Employees.Lecturers.Repositories.IRepositories;

public interface ILecturerRepository : IBaseEmployeeRepository<Lecturer, LecturerId>;
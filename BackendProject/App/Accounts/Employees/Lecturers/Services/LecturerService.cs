using BackendProject.App.Accounts.Employees.BaseEmployee.Abstractions;
using BackendProject.App.Accounts.Employees.BaseEmployee.Services;
using BackendProject.App.Accounts.Employees.Lecturers.Entities;
using BackendProject.App.Accounts.Employees.Lecturers.Repositories.IRepositories;
using BackendProject.App.Accounts.Employees.Lecturers.Services.IServices;
using BackendProject.App.Accounts.Employees.Lecturers.ValueObjects;

namespace BackendProject.App.Accounts.Employees.Lecturers.Services;

public class LecturerService(ILecturerRepository repository)
    : BaseEmployeeService<Lecturer, LecturerId, ILecturerRepository>(repository), ILecturerService
{
    protected override Lecturer GenerateEmployee(ICreateEmployeeRequest<Lecturer, LecturerId> request)
    {
        return new Lecturer
        {
            FirstName = null,
            LastName = null,
            UserName = null,
            PhoneNumber = null,
            PersonalId = null
        };
    }
}
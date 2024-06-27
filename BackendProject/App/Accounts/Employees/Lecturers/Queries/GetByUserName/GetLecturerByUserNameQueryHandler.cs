using BackendProject.App.Accounts.Employees.BaseEmployee.Queries.GetByUsername;
using BackendProject.App.Accounts.Employees.Lecturers.Dtos;
using BackendProject.App.Accounts.Employees.Lecturers.Entities;
using BackendProject.App.Accounts.Employees.Lecturers.Repositories.IRepositories;
using BackendProject.App.Accounts.Employees.Lecturers.ValueObjects;

namespace BackendProject.App.Accounts.Employees.Lecturers.Queries.GetByUserName;

public class GetLecturerByUserNameQueryHandler : BaseEmployeeGetByUsernameQueryHandler
    <Lecturer, LecturerId, LecturerDto, GetLecturerByUserNameQuery>
{
    public GetLecturerByUserNameQueryHandler(ILecturerReadRepository repository) : base(repository)
    {
    }
}
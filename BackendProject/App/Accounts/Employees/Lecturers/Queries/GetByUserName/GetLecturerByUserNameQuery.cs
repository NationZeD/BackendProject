using BackendProject.App.Accounts.Employees.BaseEmployee.Queries.GetByUsername;
using BackendProject.App.Accounts.Employees.Lecturers.Dtos;
using BackendProject.App.Accounts.Employees.Lecturers.Entities;

namespace BackendProject.App.Accounts.Employees.Lecturers.Queries.GetByUserName;

public class GetLecturerByUserNameQuery : BaseEmployeeGetByUserNameQuery<Lecturer, LecturerDto>
{
    public GetLecturerByUserNameQuery(string username) : base(username)
    {
    }
}
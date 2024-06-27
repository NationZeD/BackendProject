using BackendProject.App.Accounts.Employees.BaseEmployee.Queries.GetAll;
using BackendProject.App.Accounts.Employees.Lecturers.Dtos;
using BackendProject.App.Accounts.Employees.Lecturers.Entities;
using BackendProject.App.Accounts.Employees.Lecturers.Repositories.IRepositories;
using BackendProject.App.Accounts.Employees.Lecturers.ValueObjects;

namespace BackendProject.App.Accounts.Employees.Lecturers.Queries.GetAll;

public class GetAllLecturersQueryHandler : BaseEmployeeGetAllQueryHandler<Lecturer, LecturerId, LecturerDto, GetAllLecturersQuery>
{
    public GetAllLecturersQueryHandler(ILecturerReadRepository repo) : base(repo)
    {
    }
}
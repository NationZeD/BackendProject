using BackendProject.App.Accounts.Employees.BaseEmployee.Queries.Get;
using BackendProject.App.Accounts.Employees.Lecturers.Dtos;
using BackendProject.App.Accounts.Employees.Lecturers.Entities;
using BackendProject.App.Accounts.Employees.Lecturers.Repositories.IRepositories;
using BackendProject.App.Accounts.Employees.Lecturers.ValueObjects;

namespace BackendProject.App.Accounts.Employees.Lecturers.Queries.GetById;

public class GetLecturerByIdQueryHandler : BaseEmployeeGetQueryHandler<Lecturer, LecturerId, LecturerDto, GetLecturerByIdQuery>
{
    public GetLecturerByIdQueryHandler(ILecturerReadRepository repository) : base(repository)
    {
    }
}
using BackendProject.App.Accounts.Employees.BaseEmployee.Queries.Get;
using BackendProject.App.Accounts.Employees.Lecturers.Dtos;
using BackendProject.App.Accounts.Employees.Lecturers.Entities;

namespace BackendProject.App.Accounts.Employees.Lecturers.Queries.GetById;

public class GetLecturerByIdQuery : BaseEmployeeGetQuery<Lecturer, LecturerDto>
{
    public GetLecturerByIdQuery(Guid id) : base(id)
    {
    }
}
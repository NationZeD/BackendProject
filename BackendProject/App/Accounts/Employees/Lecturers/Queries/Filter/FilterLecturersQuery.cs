using BackendProject.App.Accounts.Employees.Lecturers.Dtos;
using BackendProject.Shared.Paging;
using MediatR;

namespace BackendProject.App.Accounts.Employees.Lecturers.Queries.Filter;

public class FilterLecturersQuery(LecturerPagingQuery request)
    : IRequest<PagedList<LecturerDto>>
{
    public LecturerPagingQuery Request { get; set; } = request;
}
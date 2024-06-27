using BackendProject.App.Accounts.Employees.Lecturers.Dtos;
using BackendProject.App.Accounts.Employees.Lecturers.Repositories.IRepositories;
using BackendProject.Shared.Paging;
using MediatR;

namespace BackendProject.App.Accounts.Employees.Lecturers.Queries.Filter;

public class FilterLecturersQueryHandler(ILecturerReadRepository repository)
    : IRequestHandler<FilterLecturersQuery, PagedList<LecturerDto>>
{
    public async Task<PagedList<LecturerDto>> Handle(FilterLecturersQuery request, CancellationToken cancellationToken)
    {
        var lecturers = await repository.FilterAsync(request.Request);
        return lecturers;
    }
}
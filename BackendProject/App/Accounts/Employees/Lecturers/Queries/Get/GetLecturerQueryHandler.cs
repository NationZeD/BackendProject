using BackendProject.App.Accounts.Employees.Lecturers.Dtos;
using BackendProject.App.Accounts.Employees.Lecturers.Repositories.IRepositories;
using BackendProject.Shared.Exceptions;
using MediatR;

namespace BackendProject.App.Accounts.Employees.Lecturers.Queries.Get;

public class GetLecturerQueryHandler(ILecturerReadRepository repository)
    : IRequestHandler<GetLecturerQuery, LecturerDto>
{
    public async Task<LecturerDto> Handle(GetLecturerQuery query, CancellationToken cancellationToken)
    {
        var request = query.Request;
        var lecturer = await repository.GetAsync(request.Id, request.Lang);
        if (lecturer == null)
            throw new NotFoundException("Lecturer");

        return lecturer;
    }
}
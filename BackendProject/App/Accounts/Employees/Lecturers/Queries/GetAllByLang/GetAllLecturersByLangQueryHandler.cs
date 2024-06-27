using BackendProject.App.Accounts.Employees.Lecturers.Dtos;
using BackendProject.App.Accounts.Employees.Lecturers.Repositories.IRepositories;
using MediatR;

namespace BackendProject.App.Accounts.Employees.Lecturers.Queries.GetAllByLang;

public class GetAllLecturersByLangQueryHandler(ILecturerReadRepository repository)
    : IRequestHandler<GetAllLecturersByLangQuery, List<LecturerDto>>
{
    public async Task<List<LecturerDto>> Handle(GetAllLecturersByLangQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetAllAsync(request.Lang);
    }
}
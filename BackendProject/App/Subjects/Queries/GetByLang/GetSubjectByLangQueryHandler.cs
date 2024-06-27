using BackendProject.App.Subjects.Dtos;
using BackendProject.App.Subjects.Repositories.IRepositories;
using MediatR;

namespace BackendProject.App.Subjects.Queries.GetByLang;

public class GetSubjectByLangQueryHandler(ISubjectReadRepository repo)
    : IRequestHandler<GetSubjectByLangQuery, SubjectDto>
{
    public async Task<SubjectDto> Handle(GetSubjectByLangQuery request, CancellationToken cancellationToken)
    {
        var result = await repo.GetByIdByLangAsync(request.Id, request.Lang);
        return result;
    }
}
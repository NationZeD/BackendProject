using BackendProject.App.Subjects.Dtos;
using BackendProject.App.Subjects.Repositories.IRepositories;
using MediatR;

namespace BackendProject.App.Subjects.Queries.GetAll;

public class GetAllSubjectsQueryHandler(ISubjectReadRepository repository)
    : IRequestHandler<GetAllSubjectsQuery, List<SubjectDto>>
{
    public async Task<List<SubjectDto>> Handle(GetAllSubjectsQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetAllAsync(request.Lang);
    }
}
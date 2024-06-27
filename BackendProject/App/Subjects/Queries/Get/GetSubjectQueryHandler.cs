using BackendProject.App.Subjects.Dtos;
using BackendProject.App.Subjects.Services.IServices;
using MediatR;

namespace BackendProject.App.Subjects.Queries.Get;

public class GetSubjectQueryHandler(ISubjectService service) : IRequestHandler<GetSubjectQuery, SubjectForm>
{
    public async Task<SubjectForm> Handle(GetSubjectQuery request, CancellationToken cancellationToken)
    {
        return await service.GetAsync(request.Id);
    }
}
using BackendProject.App.Subjects.Dtos;
using BackendProject.App.Subjects.Services.IServices;
using MediatR;

namespace BackendProject.App.Subjects.Queries.GetForm;

public class GetSubjectFormQueryHandler(ISubjectService service) : IRequestHandler<GetSubjectFormQuery, SubjectForm>
{
    public Task<SubjectForm> Handle(GetSubjectFormQuery request, CancellationToken cancellationToken)
    {
        return service.GetForm();
    }
}
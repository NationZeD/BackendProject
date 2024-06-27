using BackendProject.App.Subjects.Services.IServices;
using BackendProject.Shared.Abstractions;
using MediatR;

namespace BackendProject.App.Subjects.Commands.Create;

public class CreateSubjectCommandHandler(IUnitOfWork unitOfWork, ISubjectService service)
    : IRequestHandler<CreateSubjectCommand>
{
    public async Task Handle(CreateSubjectCommand request, CancellationToken cancellationToken)
    {
        await service.CreateAsync(request.Request);
        await unitOfWork.SaveAsync();
    }
}
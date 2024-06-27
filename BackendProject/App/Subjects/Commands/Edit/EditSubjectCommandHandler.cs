using BackendProject.App.Subjects.Services.IServices;
using BackendProject.Shared.Abstractions;
using MediatR;

namespace BackendProject.App.Subjects.Commands.Edit;

public class EditSubjectCommandHandler(ISubjectService service, IUnitOfWork unitOfWork)
    : IRequestHandler<EditSubjectCommand>
{
    public async Task Handle(EditSubjectCommand request, CancellationToken cancellationToken)
    {
        await service.UpdateAsync(request.Request);
        await unitOfWork.SaveAsync();
    }
}
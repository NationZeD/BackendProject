using BackendProject.App.Subjects.Repositories.IRepositories;
using BackendProject.App.Subjects.ValueObjects;
using BackendProject.Shared.Abstractions;
using MediatR;

namespace BackendProject.App.Subjects.Commands.Delete;

public class DeleteSubjectCommandHandler(ISubjectRepository repo, IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteSubjectCommand>
{
    public async Task Handle(DeleteSubjectCommand request, CancellationToken cancellationToken)
    {
        var subject = await repo.GetAsync(new SubjectId(request.Id));
        if (subject == null)
            throw new Exception("Subject with given Id was not found");

        repo.Delete(subject);
        await unitOfWork.SaveAsync();
    }
}
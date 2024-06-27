using MediatR;

namespace BackendProject.App.Subjects.Commands.Delete;

public record DeleteSubjectCommand(Guid Id) : IRequest;
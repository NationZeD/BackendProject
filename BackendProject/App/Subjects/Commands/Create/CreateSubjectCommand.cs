using BackendProject.App.Subjects.Dtos;
using MediatR;

namespace BackendProject.App.Subjects.Commands.Create;

public class CreateSubjectCommand(SubjectForm request) : IRequest
{
    public SubjectForm Request { get; set; } = request;
}
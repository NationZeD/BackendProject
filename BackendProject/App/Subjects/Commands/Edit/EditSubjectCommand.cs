using BackendProject.App.Subjects.Dtos;
using MediatR;

namespace BackendProject.App.Subjects.Commands.Edit;

public class EditSubjectCommand(SubjectForm request) : IRequest
{
    public SubjectForm Request { get; set; } = request;
}
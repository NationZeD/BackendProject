using BackendProject.App.Subjects.Dtos;
using MediatR;

namespace BackendProject.App.Subjects.Queries.GetForm;

public record GetSubjectFormQuery : IRequest<SubjectForm>;
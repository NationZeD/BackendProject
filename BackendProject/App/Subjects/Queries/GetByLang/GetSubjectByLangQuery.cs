using BackendProject.App.Subjects.Dtos;
using MediatR;

namespace BackendProject.App.Subjects.Queries.GetByLang;

public record GetSubjectByLangQuery(Guid Id, string Lang) : IRequest<SubjectDto>;
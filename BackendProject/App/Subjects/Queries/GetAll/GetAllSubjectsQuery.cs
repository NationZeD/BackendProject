using BackendProject.App.Subjects.Dtos;
using MediatR;

namespace BackendProject.App.Subjects.Queries.GetAll;

public record GetAllSubjectsQuery(string Lang) : IRequest<List<SubjectDto>>;
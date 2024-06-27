using BackendProject.App.Subjects.Dtos;
using BackendProject.App.Subjects.ValueObjects;
using MediatR;

namespace BackendProject.App.Subjects.Queries.Get;

public record GetSubjectQuery(SubjectId Id) : IRequest<SubjectForm>;
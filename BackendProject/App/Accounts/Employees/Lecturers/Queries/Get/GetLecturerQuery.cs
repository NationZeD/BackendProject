using BackendProject.App.Accounts.Employees.Lecturers.Dtos;
using MediatR;

namespace BackendProject.App.Accounts.Employees.Lecturers.Queries.Get;

public record GetLecturerQuery(GetLecturerRequest Request) : IRequest<LecturerDto>;
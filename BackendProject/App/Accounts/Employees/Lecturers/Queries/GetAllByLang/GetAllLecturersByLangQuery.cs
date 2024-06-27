using BackendProject.App.Accounts.Employees.Lecturers.Dtos;
using MediatR;

namespace BackendProject.App.Accounts.Employees.Lecturers.Queries.GetAllByLang;

public record GetAllLecturersByLangQuery(string Lang) : IRequest<List<LecturerDto>>;
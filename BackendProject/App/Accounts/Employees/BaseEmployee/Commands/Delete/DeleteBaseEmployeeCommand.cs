using BackendProject.Shared.Abstractions;
using MediatR;

namespace BackendProject.App.Accounts.Employees.BaseEmployee.Commands.Delete;

public record DeleteBaseEmployeeCommand<TId>(TId Id) : IRequest where TId : BaseEntityId;
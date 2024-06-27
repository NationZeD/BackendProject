using MediatR;

namespace BackendProject.App.Accounts.Employees.BaseEmployee.Commands.Edit;

public record UpdateBaseEmployeeCommand<TRequest>(TRequest Request) : IRequest;
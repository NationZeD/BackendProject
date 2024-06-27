using BackendProject.App.Auth.Dtos;
using MediatR;

namespace BackendProject.App.Accounts.Employees.BaseEmployee.Commands.SignIn;

public record SignInCommand(SignInRequest Request) : IRequest<SignInResult>;
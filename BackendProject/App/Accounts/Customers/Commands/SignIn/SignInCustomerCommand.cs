using BackendProject.App.Auth.Dtos;
using MediatR;

namespace BackendProject.App.Accounts.Customers.Commands.SignIn;

public record SignInCustomerCommand(SignInCustomerRequest Request) : IRequest<SignInResult>;
using MediatR;

namespace BackendProject.App.Accounts.Customers.Commands.SignUp;

public record SignUpCustomerCommand(SignUpCustomerRequest Request) : IRequest;
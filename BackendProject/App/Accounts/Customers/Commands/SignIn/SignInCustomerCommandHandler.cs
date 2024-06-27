using BackendProject.App.Accounts.Customers.Repositories.IRepositories;
using BackendProject.App.Auth.Dtos;
using BackendProject.App.Auth.Services.IServices;
using BackendProject.Shared.Exceptions;
using BackendProject.Shared.Extensions;
using MediatR;

namespace BackendProject.App.Accounts.Customers.Commands.SignIn;

public class SignInCustomerCommandHandler(
    ICustomerReadRepository customerReadRepo,
    ISignInService signinService)
    : IRequestHandler<SignInCustomerCommand, SignInResult>
{

    public async Task<SignInResult> Handle(SignInCustomerCommand request, CancellationToken cancellationToken)
    {
        var customerRequest = request.Request;
        customerRequest.UserName = customerRequest.UserName.ToNormalizedPhoneNumber();
        
        var customer = await customerReadRepo.GetByUserNameAsync(customerRequest.UserName);
        if (customer == null)
            throw new NotFoundException("Customer");

        if (!await signinService.CheckPasswordAsync(customer.Id.ToString(), customerRequest.Password))
            throw new Exception("Invalid credentials");

        return await signinService.SignInAsync(customer.Id.ToString());
    }
}
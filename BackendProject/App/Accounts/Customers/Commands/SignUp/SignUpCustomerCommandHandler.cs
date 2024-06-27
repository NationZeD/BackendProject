using BackendProject.App.Accounts.Customers.Services.IServices;
using BackendProject.App.Auth.Constants;
using BackendProject.App.Auth.Services.IServices;
using BackendProject.App.Verifications.Services.IServices;
using BackendProject.Shared.Abstractions;
using BackendProject.Shared.Extensions;
using MediatR;

namespace BackendProject.App.Accounts.Customers.Commands.SignUp;

public class SignUpCustomerCommandHandler(
    ICustomerService customerService,
    IVerificationService verificationService,
    IUserService userService,
    IUnitOfWork unitOfWork)
    : IRequestHandler<SignUpCustomerCommand>
{
    public async Task Handle(SignUpCustomerCommand request, CancellationToken cancellationToken)
    {
        var customerRequest = new SignUpCustomerRequest
        {
            PhoneNumber = request.Request.PhoneNumber.ToNormalizedPhoneNumber(),
            Email = request.Request.Email,
            Password = request.Request.Password,
            VerificationCode = request.Request.VerificationCode,
            FirstName = request.Request.FirstName,
            LastName = request.Request.LastName
        };

        await verificationService.VerifyAsync(customerRequest.PhoneNumber, customerRequest.VerificationCode);

        var customerId = await customerService.CreateAsync(customerRequest);

        await userService.CreateAsync(customerId.Value.ToString(), $"Customer-{customerRequest.PhoneNumber}");

        await userService.AddToRoleAsync(customerId.Value.ToString(), Roles.Customer);

        await userService.ChangePasswordAsync(customerId.Value.ToString(), customerRequest.Password);

        await unitOfWork.SaveAsync();
    }
}
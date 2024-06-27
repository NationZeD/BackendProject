using BackendProject.App.Auth.Dtos;
using BackendProject.App.Auth.Services.IServices;
using MediatR;

namespace BackendProject.App.Accounts.Employees.BaseEmployee.Commands.SignIn;

public class SignInCommandHandler(
    ISignInService signinService)
    : IRequestHandler<SignInCommand, SignInResult>
{
    public async Task<SignInResult> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        var signInRequest = request.Request;
        var result =  await signinService.SignInWithUserNameAsync($"Employee-{signInRequest.Username}");
        if (!await signinService.CheckPasswordAsync(result.Id, signInRequest.Password))
            throw new Exception("Invalid credentials");

        return result;
    }
}
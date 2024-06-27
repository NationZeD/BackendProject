using BackendProject.App.Auth.Dtos;
using BackendProject.Shared.Abstractions;

namespace BackendProject.App.Auth.Services.IServices;

public interface ISignInService : IAppService
{
    Task<bool> CheckPasswordAsync(string userId, string password);
    Task<SignInResult> SignInAsync(string userId);
    Task<SignInResult> SignInWithUserNameAsync(string username);
}
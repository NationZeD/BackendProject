using BackendProject.Shared.Abstractions;

namespace BackendProject.App.Auth.Services.IServices;

public interface IUserService : IAppService
{
    Task<string> CreateAsync(string id,string userName);
    Task ChangePasswordAsync(string userId, string password);
    Task ChangeUserNameAsync(string userId, string newUserName);
    Task AddToRoleAsync(string userId, string role);
    Task DeleteAsync(string userId);
}
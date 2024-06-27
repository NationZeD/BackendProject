using BackendProject.App.Auth.Entities;
using BackendProject.App.Auth.Services.IServices;
using BackendProject.Shared.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace BackendProject.App.Auth.Services;

public class UserService(UserManager<ApplicationUser> umng, RoleManager<IdentityRole> rmng)
    : IUserService
{
    public async Task<string> CreateAsync(string id, string userName)
    {
        userName = userName.Trim();

        var existing = await umng.FindByNameAsync(userName);
        if (existing != null)
            throw new DuplicateInstanceException("User");

        var user = new ApplicationUser
        {
            Id = id,
            UserName = userName
        };

        await umng.CreateAsync(user);

        return user.Id;
    }

    public async Task ChangePasswordAsync(string userId, string password)
    {
        var user = await umng.FindByIdAsync(userId);
        if (user == null) return;

        if (string.IsNullOrEmpty(password)) return;

        await umng.RemovePasswordAsync(user);

        await umng.AddPasswordAsync(user, password);
    }

    public async Task ChangeUserNameAsync(string userId, string newUserName)
    {
        var existing = await umng.FindByNameAsync(newUserName);
        if (existing != null)
        {
            if (existing.Id != userId)
            {
                throw new DuplicateInstanceException("User");
            }
        }

        var user = await umng.FindByIdAsync(userId);
        if (user is null) return;
        user.UserName = newUserName;
        await umng.UpdateAsync(user);
    }

    public async Task AddToRoleAsync(string userId, string role)
    {
        if (!await rmng.RoleExistsAsync(role))
        {
            await rmng.CreateAsync(new IdentityRole(role));
        }

        var user = await umng.FindByIdAsync(userId);

        if (user == null) return;

        await umng.AddToRoleAsync(user, role);
    }

    public async Task DeleteAsync(string userId)
    {
        var user = await umng.FindByIdAsync(userId);
        if (user is null) return;

        await umng.DeleteAsync(user);
    }
}
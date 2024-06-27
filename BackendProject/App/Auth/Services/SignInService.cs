using System.IdentityModel.Tokens.Jwt;
using System.Text;
using BackendProject.App.Auth.Entities;
using BackendProject.App.Auth.Services.IServices;
using BackendProject.Shared;
using BackendProject.Shared.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SignInResult = BackendProject.App.Auth.Dtos.SignInResult;

namespace BackendProject.App.Auth.Services;

public class SignInService(
    UserManager<ApplicationUser> umng,
    SignInManager<ApplicationUser> smng,
    IConfiguration configuration)
    : ISignInService
{
    public async Task<bool> CheckPasswordAsync(string userId, string password)
    {
        var user = await umng.FindByIdAsync(userId);
        if (user is null)
            throw new NotFoundException("User");

        var result =
            await smng.CheckPasswordSignInAsync(user, password, false);

        return result.Succeeded;
    }

    public async Task<SignInResult> SignInAsync(string userId)
    {
        var user = await umng.FindByIdAsync(userId);
        if (user is null)
            throw new NotFoundException("User");
        var descriptor = new SecurityTokenDescriptor
        {
            Subject = (await smng.CreateUserPrincipalAsync(user))
                .Identities.First(),
            Expires = NormalizedTime.Now.AddDays(365).DateTime,
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                    configuration["BearerToken:Key"])),
                SecurityAlgorithms.HmacSha256Signature)
        };
        var handler = new JwtSecurityTokenHandler();
        var secToken = new JwtSecurityTokenHandler()
            .CreateToken(descriptor);
        var token = handler.WriteToken(secToken);
        var userRoles = await umng.GetRolesAsync(user);
        return new SignInResult
        {
            Id = userId,
            AccessToken = token,
            ExpiresAt = 1,
            Role = userRoles.FirstOrDefault()
        };
    }
    
    public async Task<SignInResult> SignInWithUserNameAsync(string username)
    {
        var user = await umng.FindByNameAsync(username);
        if (user is null)
            throw new NotFoundException("User");
        var descriptor = new SecurityTokenDescriptor
        {
            Subject = (await smng.CreateUserPrincipalAsync(user))
                .Identities.First(),
            Expires = NormalizedTime.Now.AddDays(365).DateTime,
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                    configuration["BearerToken:Key"])),
                SecurityAlgorithms.HmacSha256Signature)
        };
        var handler = new JwtSecurityTokenHandler();
        var secToken = new JwtSecurityTokenHandler()
            .CreateToken(descriptor);
        var token = handler.WriteToken(secToken);
        var userRoles = await umng.GetRolesAsync(user);
        return new SignInResult
        {
            Id = user.Id,
            AccessToken = token,
            ExpiresAt = 1,
            Role = userRoles.FirstOrDefault()
        };
    }
}
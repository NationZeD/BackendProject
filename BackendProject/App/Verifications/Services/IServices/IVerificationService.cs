using BackendProject.Shared.Abstractions;

namespace BackendProject.App.Verifications.Services.IServices;

public interface IVerificationService : IAppService
{
    Task SendVerificationCodeAsync(string phoneNumber);
    Task<bool> VerifyAsync(string phoneNumber, int code);
}
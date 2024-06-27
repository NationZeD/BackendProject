using BackendProject.App.Senders.Services.IServices;
using BackendProject.App.Verifications.Entities;
using BackendProject.App.Verifications.Repositories.IRepositories;
using BackendProject.App.Verifications.Services.IServices;
using BackendProject.Shared.Extensions;

namespace BackendProject.App.Verifications.Services;

public class VerificationService : IVerificationService
{
    private readonly IOTPCodeRepository _repository;
    private readonly ISmsSender _sender;

    public VerificationService(IOTPCodeRepository repository, ISmsSender sender)
    {
        _repository = repository;
        _sender = sender;
    }

    public async Task SendVerificationCodeAsync(string phoneNumber)
    {
        var otpCode = new OTPCode(phoneNumber);

        await _sender.SendAsync(otpCode.Source, $"Your verification code is: {otpCode.Code}");

        await _repository.CreateAsync(otpCode);
    }

    public async Task<bool> VerifyAsync(string phoneNumber, int code)
    {
        phoneNumber = phoneNumber.ToNormalizedPhoneNumber();
        var codes = await _repository.GetAllBySourceAsync(phoneNumber);
        
        if (!codes.Any(x => x.Suit(code)))
            throw new Exception("Code does not match or expired");

        _repository.Delete(codes);
        return true;
    }
}
using BackendProject.App.Verifications.Services.IServices;
using BackendProject.Shared.Abstractions;
using MediatR;

namespace BackendProject.App.Verifications.Commands.SendVerificationCode;

public class SendVerificationCommandHandler(IVerificationService verificationService, IUnitOfWork unitOfWork)
    : IRequestHandler<SendVerificationCodeCommand>
{
    public async Task Handle(SendVerificationCodeCommand request, CancellationToken cancellationToken)
    {
        await verificationService.SendVerificationCodeAsync(request.Request.PhoneNumber);
        await unitOfWork.SaveAsync();
    }
}
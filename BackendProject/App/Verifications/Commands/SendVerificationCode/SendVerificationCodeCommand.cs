using MediatR;

namespace BackendProject.App.Verifications.Commands.SendVerificationCode;

public record SendVerificationCodeCommand(SendVerificationCodeRequest Request) : IRequest;
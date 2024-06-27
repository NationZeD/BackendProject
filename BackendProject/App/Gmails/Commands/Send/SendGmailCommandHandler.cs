using BackendProject.App.Gmails.Services.IServices;
using BackendProject.Shared.Abstractions;
using MediatR;

namespace BackendProject.App.Gmails.Commands.Send;

public class SendGmailCommandHandler(IGmailService gmailService, IUnitOfWork unitOfWork)
    : IRequestHandler<SendGmailCommand>
{
    public async Task Handle(SendGmailCommand request, CancellationToken cancellationToken)
    {
        var gmailRequest = request.Request;
        await gmailService.SendGmail(gmailRequest);
        await unitOfWork.SaveAsync();
    }
}
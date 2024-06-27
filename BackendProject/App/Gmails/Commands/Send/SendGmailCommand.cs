using MediatR;

namespace BackendProject.App.Gmails.Commands.Send;

public record SendGmailCommand(SendGmailRequest Request) : IRequest;
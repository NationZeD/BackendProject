using BackendProject.App.Gmails.Commands.Send;
using BackendProject.Shared;
using BackendProject.Shared.Abstractions;

namespace BackendProject.App.Gmails.Services.IServices;

public interface IGmailService : IAppService
{
    Task<ServiceResponse> SendGmail(SendGmailRequest request);
}
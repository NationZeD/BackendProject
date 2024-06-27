using BackendProject.Shared.Abstractions;

namespace BackendProject.App.Senders.Services.IServices;

public interface ISmsSender : IAppService
{
    Task SendAsync(string phoneNumber, string text);
}
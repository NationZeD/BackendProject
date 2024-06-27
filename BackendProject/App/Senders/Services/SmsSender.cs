using BackendProject.App.Senders.REST;
using BackendProject.App.Senders.Services.IServices;
using BackendProject.Shared.Extensions;

namespace BackendProject.App.Senders.Services;

public class SmsSender : ISmsSender
{
    private readonly SmsSenderClient _client;

    public SmsSender(SmsSenderClient client)
    {
        _client = client;
    }

    public async Task SendAsync(string phoneNumber, string text)
    {
        await _client.SendAsync(phoneNumber.ToNormalizedPhoneNumber(), text);
    }
}
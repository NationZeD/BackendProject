using BackendProject.Shared.REST;

namespace BackendProject.App.Senders.REST;

public class SmsSenderClient(IHttpClientFactory httpClientFactory)
    : RestClient(httpClientFactory,
        "SMS")

{
    public async Task SendAsync(string phoneNumber, string text)
    {
        await GetAsync("", new QueryParameter
        {
            Key = "username",
            Value = ""
        }, new QueryParameter
        {
            Key = "password",
            Value = ""
        }, new QueryParameter
        {
            Key = "client_id",
            Value = ""
        }, new QueryParameter
        {
            Key = "service_id",
            Value = ""
        },new QueryParameter{
            Key = "to",
            Value = "+995"+phoneNumber
        },new QueryParameter{
            Key = "text",
            Value = text
        });
    }
}
using BackendProject.Shared.REST;

namespace BackendProject.App.Senders.REST;

public class SmsSenderClient(IHttpClientFactory httpClientFactory)
    : RestClient(httpClientFactory,
        "SMS")

{
    public async Task SendAsync(string phoneNumber, string text)
    {
        await GetAsync("sendsms.php", new QueryParameter
        {
            Key = "username",
            Value = "gulia"
        }, new QueryParameter
        {
            Key = "password",
            Value = "67YBGfCl93"
        }, new QueryParameter
        {
            Key = "client_id",
            Value = "1035"
        }, new QueryParameter
        {
            Key = "service_id",
            Value = "2860"
        },new QueryParameter{
            Key = "to",
            Value = "+995"+phoneNumber
        },new QueryParameter{
            Key = "text",
            Value = text
        });
    }
}
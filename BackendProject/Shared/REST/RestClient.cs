using System.Text;
using Newtonsoft.Json;

namespace BackendProject.Shared.REST;

public abstract class RestClient 
{
     private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _clientName;

        protected RestClient(IHttpClientFactory httpClientFactory, string clientName)
        {
            _httpClientFactory = httpClientFactory;
            _clientName = clientName;
        }

        protected async Task<T> GetAsync<T>(string url, string parameter = "")
        {
            using (var httpClient = CreateClient())
            {
                url = $"{url}/{parameter}";
                var response = await httpClient.GetStringAsync(url);
                return JsonConvert.DeserializeObject<T>(response);
            }
        }

        protected async Task<string> GetAsync(string url, string parameter = "")
        {
            using (var httpClient = CreateClient())
            {
                url = $"{url}/{parameter}";
                var response = await httpClient.GetStringAsync(url);
                return response;
            }
        }


        protected async Task<T> GetAsync<T>(string url, params QueryParameter[] parameters)
        {
            using (var httpClient = CreateClient())
            {
                url = $"{url}?";

                foreach (var parameter in parameters)
                {
                    url += $"{parameter.Key}={parameter.Value}&";
                }

                url = new string(url.Skip(0).Take(url.Length - 1).ToArray());

                var response = await httpClient.GetStringAsync(url);
                return JsonConvert.DeserializeObject<T>(response);
            }
        }

        protected async Task<string> GetAsync(string url, params QueryParameter[] parameters)
        {
            using (var httpClient = CreateClient())
            {
                url = $"{url}?";

                foreach (var parameter in parameters)
                {
                    url += $"{parameter.Key}={parameter.Value}&";
                }
                url = url.Remove(url.Length - 1);
                var response = await httpClient.GetStringAsync(url);
                return response;
            }
        }
        protected async Task<string> GetAsync(string url, IEnumerable<QueryParameter> parameters)
        {
            using (var httpClient = CreateClient())
            {
                url = $"{url}?";

                foreach (var parameter in parameters)
                {
                    url += $"{parameter.Key}={parameter.Value}&";
                }
                url = url.Remove(url.Length - 1);
                var response = await httpClient.GetStringAsync(url);
                return response;
            }
        }
        
        protected async Task<bool> PostQueryAsync(string url, params QueryParameter[] parameters)
        {
            using (var httpClient = CreateClient())
            {
                url = $"{url}?";
                var json = "{}";
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                foreach (var parameter in parameters)
                {
                    url += $"{parameter.Key}={parameter.Value}&";
                }
                url = url.Remove(url.Length - 1);
                var response = await httpClient.GetAsync(url);
                var ct = await response.Content.ReadAsStringAsync();
                return response.IsSuccessStatusCode;
            }
        }
        protected async Task<bool> PostQueryAsync(string url,  IEnumerable<QueryParameter> parameters)
        {
            using (var httpClient = CreateClient())
            {
                url = $"{url}?";
                var json = "{}";
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                foreach (var parameter in parameters)
                {
                    url += $"{parameter.Key}={parameter.Value}&";
                }
                url = url.Remove(url.Length - 1);
                var response = await httpClient.GetAsync(url);
                var ct = await response.Content.ReadAsStringAsync();
                return response.IsSuccessStatusCode;
            }
        }
        
        
        protected async Task<bool> PostAsync(string url, object parameter)
        {
            using (var httpClient = CreateClient())
            {
                url = $"{url}";
                var json = JsonConvert.SerializeObject(parameter);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(url, content);
                var ct = await response.Content.ReadAsStringAsync();
                return response.IsSuccessStatusCode;
            }
        }

        protected async Task<T> PostAsync<T>(string url, object parameter)
        {
            using (var httpClient = CreateClient())
            {
                url = $"{url}";
                var content = GetContent(parameter);
                var response = await httpClient.PostAsync(url, content);
                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(data);
            }
        }

        protected StringContent GetContent(object parameter)
        {
            var json = JsonConvert.SerializeObject(parameter);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return content;
        }

        protected virtual HttpClient CreateClient()
        {
            var client = _httpClientFactory.CreateClient(_clientName);
            client.Timeout = TimeSpan.FromHours(1);
            return client;
        }
}
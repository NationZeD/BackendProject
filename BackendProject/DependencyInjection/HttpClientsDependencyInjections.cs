using BackendProject.Shared.REST;

namespace BackendProject.DependencyInjection;

public static class HttpClientsDependencyInjections
{
    public static IServiceCollection AddAPIClients(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddHttpClient("SMS",
            client =>
            {
                client.BaseAddress = new Uri(configuration.GetValue<string>("SMS:BaseUrl"));
                client.DefaultRequestHeaders.TryAddWithoutValidation("MSG_HEADER",
                    configuration.GetValue<string>("SMS:MSG_HEADER"));
            });

        var restClientType = typeof(RestClient);

        var restClientImplementations = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Where(p => !p.IsAbstract && restClientType.IsAssignableFrom(p) && p != restClientType)
            .ToList();

        foreach (var implementation in restClientImplementations)
        {
            services.AddTransient(implementation);
        }

        return services;
    }
}
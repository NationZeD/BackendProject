using BackendProject.Shared.Abstractions;

namespace BackendProject.DependencyInjection;

public static class ServiceDependencyInjection
{
    public static void AddServices(this IServiceCollection services)
    {
        var appServiceType = typeof(IAppService);
        var appServiceImplementations = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Where(p => p.GetInterfaces().Any(i => i != appServiceType && appServiceType.IsAssignableFrom(i)))
            .ToList();

        foreach (var implementation in appServiceImplementations)
        {
            if (!implementation.IsAbstract)
            {
                var interfaces = implementation.GetInterfaces().Where(i => i != appServiceType);
                foreach (var @interface in interfaces)
                {
                    services.AddScoped(@interface, implementation);
                }
            }
        }
    }
}
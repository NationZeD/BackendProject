using BackendProject.Shared.Abstractions;
using BackendProject.Shared.Aspects.Transactional;

namespace BackendProject.DependencyInjection;

public static class RepositoryDependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<TransactionalInterceptor>();

        var appServiceType = typeof(IRepository);
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

        return services;
    }
}
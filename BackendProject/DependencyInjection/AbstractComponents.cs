using BackendProject.Shared.Abstractions;

namespace BackendProject.DependencyInjection;

public static class AbstractComponents
{
    public static void AddAbstractComponents(this IServiceCollection services)
    {
        var type = typeof(IAbstractComponent);

        var implementations = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Where(p => !p.IsAbstract && type.IsAssignableFrom(p) && p != type)
            .ToList();

        foreach (var implementation in implementations)
        {
            services.AddTransient(implementation);
        }
    }
}
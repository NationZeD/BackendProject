namespace BackendProject.DependencyInjection;

public static class MediatRDependencyInjection
{
    public static void AddMediatr(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(Program).Assembly);
        });
    }
}
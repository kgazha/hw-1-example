using System.Reflection;
using HomeWorkExample.Interfaces;
using HomeWorkExample.Repositories;

namespace HomeWorkExample;

public static class DependencyInjection
{
    public static IServiceCollection AddCustomServices(this IServiceCollection services)
    {
        services.AddRepositories();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        
        return services;
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddSingleton<ISalaryRepository, SalaryRepository>();
    }
}
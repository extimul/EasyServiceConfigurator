using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EasyServiceConfigurator;

public static class ServiceConfigurationExtensions
{
    public static void ConfigureServicesFromAssemblies(this IServiceCollection services, IEnumerable<Assembly?> assemblies)
    {
        foreach (var assembly in assemblies)
            services.ConfigureServicesFromAssembly(assembly);
    }

    public static void ConfigureServicesFromAssembly(this IServiceCollection services, Assembly? assembly = null,
        params object[]? additionalServices)
    {
        assembly ??= Assembly.GetCallingAssembly();

        ServiceConfigurator.BaseConfigure<IServicesConfigurator, IServiceCollection>(assembly, (configuration) =>
        {
            configuration?.ConfigureServices(services, additionalServices);
        });
    }
}

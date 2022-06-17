using Microsoft.AspNetCore.Builder;
using System.Reflection;

namespace EasyServiceConfigurator.AspNet;

public static class ServiceConfigurationExtensions
{
    public static void ConfigureFromAssemblies(this IApplicationBuilder app, IEnumerable<Assembly?> assemblies)
    {
        foreach (var assembly in assemblies)
            app.ConfigureFromAssembly(assembly);
    }

    public static void ConfigureFromAssembly(this IApplicationBuilder app, Assembly? assembly = null)
    {
        assembly ??= Assembly.GetCallingAssembly();

        ServiceConfigurator.BaseConfigure<IAppConfigurator, IApplicationBuilder>(assembly, (configuration) =>
        {
            configuration?.Configure(app);
        });
    }
}

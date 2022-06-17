using System.Reflection;

namespace EasyServiceConfigurator;

public class ServiceConfigurator
{
    public static void BaseConfigure<TInterface, TInstance>(Assembly assembly,
        Action<TInterface> action)
    {
        var interfaceType = typeof(TInterface);
        var types = assembly.GetTypes()
            .Where(interfaceType.IsAssignableFrom)
            .OrderBy(x => x.GetAttributeValue<ServiceLoadPriorityAttribute, int>(selector
                => selector.Priority))
            .ToArray();

        foreach (var type in types)
        {
            var configuration = (TInterface)Activator.CreateInstance(type)!;
            action?.Invoke(configuration);
        }
    }
}

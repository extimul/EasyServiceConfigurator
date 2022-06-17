namespace EasyServiceConfigurator;

[AttributeUsage(AttributeTargets.Class)]
public class ServiceLoadPriorityAttribute : Attribute
{

    public ServiceLoadPriorityAttribute(int priority)
    {
        Priority = priority;
    }

    public int Priority { get; }
}

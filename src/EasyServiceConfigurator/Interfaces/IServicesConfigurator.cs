using Microsoft.Extensions.DependencyInjection;

namespace EasyServiceConfigurator;

public interface IServicesConfigurator
{
    public void ConfigureServices(IServiceCollection services, params object[]? additionalServices);
}

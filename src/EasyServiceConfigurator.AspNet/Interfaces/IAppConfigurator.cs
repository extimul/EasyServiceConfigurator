using Microsoft.AspNetCore.Builder;

namespace EasyServiceConfigurator.AspNet;

public interface IAppConfigurator
{
    public void Configure(IApplicationBuilder app);
}

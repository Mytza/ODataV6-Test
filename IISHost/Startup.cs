using Microsoft.Extensions.DependencyInjection;
using Owin;
using WebApi;


namespace IISHost
{
    public class Startup : WebApiStartup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var services = new ServiceCollection();
            MakeConfiguration(appBuilder);
            ConfigureServices(services);
        }

        public void ConfigureServices(IServiceCollection services)
        {

        }
    }
}
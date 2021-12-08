using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AbpMvc
{
    public class AbpMvcWebTestStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<AbpMvcWebTestModule>();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.InitializeApplication();
        }
    }
}

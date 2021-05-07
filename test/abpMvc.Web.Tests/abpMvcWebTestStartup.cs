using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace abpMvc
{
    public class abpMvcWebTestStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<abpMvcWebTestModule>();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.InitializeApplication();
        }
    }
}

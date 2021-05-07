using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace abpMvc.EntityFrameworkCore
{
    [DependsOn(
        typeof(abpMvcEntityFrameworkCoreModule)
    )]
    public class abpMvcEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<abpMvcMigrationsDbContext>();
        }
    }
}
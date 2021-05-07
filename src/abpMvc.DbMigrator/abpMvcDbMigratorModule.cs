using abpMvc.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace abpMvc.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(abpMvcEntityFrameworkCoreDbMigrationsModule),
        typeof(abpMvcApplicationContractsModule)
    )]
    public class abpMvcDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options =>
            {
                options.IsJobExecutionEnabled = false;
            });
        }
    }
}
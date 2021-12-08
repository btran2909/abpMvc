using AbpMvc.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace AbpMvc.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AbpMvcEntityFrameworkCoreModule),
        typeof(AbpMvcApplicationContractsModule)
    )]
    public class AbpMvcDbMigratorModule : AbpModule
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

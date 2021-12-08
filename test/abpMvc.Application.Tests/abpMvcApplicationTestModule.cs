using Volo.Abp.Modularity;

namespace AbpMvc
{
    [DependsOn(
        typeof(AbpMvcApplicationModule),
        typeof(AbpMvcDomainTestModule)
        )]
    public class AbpMvcApplicationTestModule : AbpModule
    {

    }
}
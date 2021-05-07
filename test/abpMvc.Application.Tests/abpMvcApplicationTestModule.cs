using Volo.Abp.Modularity;

namespace abpMvc
{
    [DependsOn(
        typeof(abpMvcApplicationModule),
        typeof(abpMvcDomainTestModule)
        )]
    public class abpMvcApplicationTestModule : AbpModule
    {

    }
}
using AbpMvc.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace AbpMvc
{
    [DependsOn(
        typeof(AbpMvcEntityFrameworkCoreTestModule)
        )]
    public class AbpMvcDomainTestModule : AbpModule
    {

    }
}
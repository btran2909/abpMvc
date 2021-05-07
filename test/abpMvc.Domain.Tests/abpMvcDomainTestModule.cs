using abpMvc.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace abpMvc
{
    [DependsOn(
        typeof(abpMvcEntityFrameworkCoreTestModule)
        )]
    public class abpMvcDomainTestModule : AbpModule
    {

    }
}
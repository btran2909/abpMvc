using abpMvc.Localization;
using Volo.Abp.AspNetCore.Components;

namespace abpMvc.Blazor.Server.Tiered
{
    public abstract class abpMvcComponentBase : AbpComponentBase
    {
        protected abpMvcComponentBase()
        {
            LocalizationResource = typeof(abpMvcResource);
        }
    }
}

using abpMvc.Localization;
using Volo.Abp.AspNetCore.Components;

namespace abpMvc.Blazor.Server
{
    public abstract class abpMvcComponentBase : AbpComponentBase
    {
        protected abpMvcComponentBase()
        {
            LocalizationResource = typeof(abpMvcResource);
        }
    }
}

using AbpMvc.Localization;
using Volo.Abp.Application.Services;

namespace AbpMvc
{
    /* Inherit your application services from this class.
     */
    public abstract class AbpMvcAppService : ApplicationService
    {
        protected AbpMvcAppService()
        {
            LocalizationResource = typeof(AbpMvcResource);
        }
    }
}

using abpMvc.Localization;
using Volo.Abp.Application.Services;

namespace abpMvc
{
    /* Inherit your application services from this class.
     */
    public abstract class abpMvcAppService : ApplicationService
    {
        protected abpMvcAppService()
        {
            LocalizationResource = typeof(abpMvcResource);
        }
    }
}

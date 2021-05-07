using abpMvc.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace abpMvc.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class abpMvcController : AbpController
    {
        protected abpMvcController()
        {
            LocalizationResource = typeof(abpMvcResource);
        }
    }
}
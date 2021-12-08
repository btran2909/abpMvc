using AbpMvc.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AbpMvc.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class AbpMvcController : AbpController
    {
        protected AbpMvcController()
        {
            LocalizationResource = typeof(AbpMvcResource);
        }
    }
}
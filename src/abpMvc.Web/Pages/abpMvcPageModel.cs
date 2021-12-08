using AbpMvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace AbpMvc.Web.Pages
{
    public abstract class AbpMvcPageModel : AbpPageModel
    {
        protected AbpMvcPageModel()
        {
            LocalizationResourceType = typeof(AbpMvcResource);
        }
    }
}
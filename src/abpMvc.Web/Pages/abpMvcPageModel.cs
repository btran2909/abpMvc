using abpMvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace abpMvc.Web.Pages
{
    public abstract class abpMvcPageModel : AbpPageModel
    {
        protected abpMvcPageModel()
        {
            LocalizationResourceType = typeof(abpMvcResource);
        }
    }
}
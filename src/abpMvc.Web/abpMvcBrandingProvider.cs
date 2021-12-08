using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace AbpMvc.Web
{
    [Dependency(ReplaceServices = true)]
    public class AbpMvcBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "AbpMvc";
    }
}

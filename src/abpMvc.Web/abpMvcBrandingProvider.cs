using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace abpMvc.Web
{
    [Dependency(ReplaceServices = true)]
    public class abpMvcBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "abpMvc";
    }
}

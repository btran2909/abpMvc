using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace abpMvc.Blazor.Server.Tiered
{
    [Dependency(ReplaceServices = true)]
    public class abpMvcBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "abpMvc";
    }
}

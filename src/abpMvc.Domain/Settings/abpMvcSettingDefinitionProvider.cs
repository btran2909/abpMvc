using Volo.Abp.Settings;

namespace AbpMvc.Settings
{
    public class AbpMvcSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(AbpMvcSettings.MySetting1));
        }
    }
}

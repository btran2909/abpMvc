using Volo.Abp.Settings;

namespace abpMvc.Settings
{
    public class abpMvcSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(abpMvcSettings.MySetting1));
        }
    }
}

using Volo.Abp.Settings;

namespace DakSite.Settings;

public class DakSiteSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(DakSiteSettings.MySetting1));
    }
}

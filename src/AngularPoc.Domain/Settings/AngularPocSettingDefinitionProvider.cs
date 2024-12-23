using Volo.Abp.Settings;

namespace AngularPoc.Settings;

public class AngularPocSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(AngularPocSettings.MySetting1));
    }
}

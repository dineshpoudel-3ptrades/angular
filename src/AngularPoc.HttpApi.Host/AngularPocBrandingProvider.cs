using Microsoft.Extensions.Localization;
using AngularPoc.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace AngularPoc;

[Dependency(ReplaceServices = true)]
public class AngularPocBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<AngularPocResource> _localizer;

    public AngularPocBrandingProvider(IStringLocalizer<AngularPocResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}

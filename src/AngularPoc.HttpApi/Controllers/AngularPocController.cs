using AngularPoc.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AngularPoc.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class AngularPocController : AbpControllerBase
{
    protected AngularPocController()
    {
        LocalizationResource = typeof(AngularPocResource);
    }
}

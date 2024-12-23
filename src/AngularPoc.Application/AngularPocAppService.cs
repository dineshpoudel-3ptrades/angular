using AngularPoc.Localization;
using Volo.Abp.Application.Services;

namespace AngularPoc;

/* Inherit your application services from this class.
 */
public abstract class AngularPocAppService : ApplicationService
{
    protected AngularPocAppService()
    {
        LocalizationResource = typeof(AngularPocResource);
    }
}

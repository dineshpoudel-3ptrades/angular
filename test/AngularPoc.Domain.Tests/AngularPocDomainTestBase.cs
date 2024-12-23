using Volo.Abp.Modularity;

namespace AngularPoc;

/* Inherit from this class for your domain layer tests. */
public abstract class AngularPocDomainTestBase<TStartupModule> : AngularPocTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}

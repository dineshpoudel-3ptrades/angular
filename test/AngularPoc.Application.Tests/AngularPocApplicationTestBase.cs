using Volo.Abp.Modularity;

namespace AngularPoc;

public abstract class AngularPocApplicationTestBase<TStartupModule> : AngularPocTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}

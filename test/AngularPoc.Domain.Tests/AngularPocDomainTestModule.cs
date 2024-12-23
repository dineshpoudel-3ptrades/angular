using Volo.Abp.Modularity;

namespace AngularPoc;

[DependsOn(
    typeof(AngularPocDomainModule),
    typeof(AngularPocTestBaseModule)
)]
public class AngularPocDomainTestModule : AbpModule
{

}

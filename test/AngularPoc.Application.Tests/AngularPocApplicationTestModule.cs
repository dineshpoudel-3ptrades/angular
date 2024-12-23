using Volo.Abp.Modularity;

namespace AngularPoc;

[DependsOn(
    typeof(AngularPocApplicationModule),
    typeof(AngularPocDomainTestModule)
)]
public class AngularPocApplicationTestModule : AbpModule
{

}

using AngularPoc.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace AngularPoc.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AngularPocEntityFrameworkCoreModule),
    typeof(AngularPocApplicationContractsModule)
)]
public class AngularPocDbMigratorModule : AbpModule
{
}

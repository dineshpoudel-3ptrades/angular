using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace AngularPoc.Data;

/* This is used if database provider does't define
 * IAngularPocDbSchemaMigrator implementation.
 */
public class NullAngularPocDbSchemaMigrator : IAngularPocDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}

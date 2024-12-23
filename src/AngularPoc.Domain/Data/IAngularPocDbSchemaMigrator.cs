using System.Threading.Tasks;

namespace AngularPoc.Data;

public interface IAngularPocDbSchemaMigrator
{
    Task MigrateAsync();
}

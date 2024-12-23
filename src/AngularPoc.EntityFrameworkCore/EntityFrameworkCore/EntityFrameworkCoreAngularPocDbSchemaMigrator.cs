using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AngularPoc.Data;
using Volo.Abp.DependencyInjection;

namespace AngularPoc.EntityFrameworkCore;

public class EntityFrameworkCoreAngularPocDbSchemaMigrator
    : IAngularPocDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreAngularPocDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the AngularPocDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<AngularPocDbContext>()
            .Database
            .MigrateAsync();
    }
}

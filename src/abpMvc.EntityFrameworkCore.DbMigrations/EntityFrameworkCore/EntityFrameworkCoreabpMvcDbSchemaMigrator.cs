using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using abpMvc.Data;
using Volo.Abp.DependencyInjection;

namespace abpMvc.EntityFrameworkCore
{
    public class EntityFrameworkCoreabpMvcDbSchemaMigrator
        : IabpMvcDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreabpMvcDbSchemaMigrator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the abpMvcMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<abpMvcMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
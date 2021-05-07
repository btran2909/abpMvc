using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using abpMvc.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.MultiTenancy;

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
            /* We intentionally resolving the DbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope (connection string is dynamically resolved).
             */

            var dbContextType = _serviceProvider.GetRequiredService<ICurrentTenant>().IsAvailable
                ? typeof(abpMvcTenantMigrationsDbContext)
                : typeof(abpMvcMigrationsDbContext);

            await ((DbContext) _serviceProvider.GetRequiredService(dbContextType))
                .Database
                .MigrateAsync();
        }
    }
}

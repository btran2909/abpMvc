using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AbpMvc.Data;
using Volo.Abp.DependencyInjection;

namespace AbpMvc.EntityFrameworkCore
{
    public class EntityFrameworkCoreAbpMvcDbSchemaMigrator
        : IAbpMvcDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreAbpMvcDbSchemaMigrator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the AbpMvcDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<AbpMvcDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}

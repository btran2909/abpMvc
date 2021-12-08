using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace AbpMvc.Data
{
    /* This is used if database provider does't define
     * IAbpMvcDbSchemaMigrator implementation.
     */
    public class NullAbpMvcDbSchemaMigrator : IAbpMvcDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}
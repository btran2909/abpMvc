using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace abpMvc.Data
{
    /* This is used if database provider does't define
     * IabpMvcDbSchemaMigrator implementation.
     */
    public class NullabpMvcDbSchemaMigrator : IabpMvcDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}
using System.Threading.Tasks;

namespace AbpMvc.Data
{
    public interface IAbpMvcDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
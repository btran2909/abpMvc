using System.Threading.Tasks;

namespace abpMvc.Data
{
    public interface IabpMvcDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
using Microsoft.EntityFrameworkCore;

namespace abpMvc.EntityFrameworkCore
{
    public class abpMvcMigrationsDbContextFactory :
        abpMvcMigrationsDbContextFactoryBase<abpMvcMigrationsDbContext>
    {
        protected override abpMvcMigrationsDbContext CreateDbContext(
            DbContextOptions<abpMvcMigrationsDbContext> dbContextOptions)
        {
            return new abpMvcMigrationsDbContext(dbContextOptions);
        }
    }
}

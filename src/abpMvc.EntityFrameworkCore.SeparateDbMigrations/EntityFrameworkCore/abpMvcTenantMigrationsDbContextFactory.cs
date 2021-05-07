using Microsoft.EntityFrameworkCore;

namespace abpMvc.EntityFrameworkCore
{
    public class abpMvcTenantMigrationsDbContextFactory :
        abpMvcMigrationsDbContextFactoryBase<abpMvcTenantMigrationsDbContext>
    {
        protected override abpMvcTenantMigrationsDbContext CreateDbContext(
            DbContextOptions<abpMvcTenantMigrationsDbContext> dbContextOptions)
        {
            return new abpMvcTenantMigrationsDbContext(dbContextOptions);
        }
    }
}

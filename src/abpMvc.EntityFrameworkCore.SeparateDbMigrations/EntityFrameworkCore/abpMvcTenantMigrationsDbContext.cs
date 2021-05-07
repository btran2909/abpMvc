using Microsoft.EntityFrameworkCore;
using Volo.Abp.MultiTenancy;

namespace abpMvc.EntityFrameworkCore
{
    public class abpMvcTenantMigrationsDbContext : abpMvcMigrationsDbContextBase<abpMvcTenantMigrationsDbContext>
    {
        public abpMvcTenantMigrationsDbContext(DbContextOptions<abpMvcTenantMigrationsDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.SetMultiTenancySide(MultiTenancySides.Tenant);

            base.OnModelCreating(builder);
        }
    }
}

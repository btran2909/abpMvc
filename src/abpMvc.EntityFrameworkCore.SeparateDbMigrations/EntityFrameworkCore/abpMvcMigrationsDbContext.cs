using Microsoft.EntityFrameworkCore;
using Volo.Abp.MultiTenancy;

namespace abpMvc.EntityFrameworkCore
{
    public class abpMvcMigrationsDbContext : abpMvcMigrationsDbContextBase<abpMvcMigrationsDbContext>
    {
        public abpMvcMigrationsDbContext(DbContextOptions<abpMvcMigrationsDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.SetMultiTenancySide(MultiTenancySides.Both);

            base.OnModelCreating(builder);
        }
    }
}

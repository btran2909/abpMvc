using AbpMvc.Authors;
using AbpMvc.Books;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.LanguageManagement.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TextTemplateManagement.EntityFrameworkCore;
using Volo.Saas.EntityFrameworkCore;
using Volo.Saas.Editions;
using Volo.Saas.Tenants;
using Volo.Payment.EntityFrameworkCore;

namespace AbpMvc.EntityFrameworkCore
{
    [ReplaceDbContext(typeof(IIdentityProDbContext))]
    [ReplaceDbContext(typeof(ISaasDbContext))]
    [ConnectionStringName("Default")]
    public class AbpMvcDbContext :
        AbpDbContext<AbpMvcDbContext>,
        IIdentityProDbContext,
        ISaasDbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        /* Add DbSet properties for your Aggregate Roots / Entities here. */

        #region Entities from the modules

        /* Notice: We only implemented IIdentityProDbContext and ISaasDbContext
         * and replaced them for this DbContext. This allows you to perform JOIN
         * queries for the entities of these modules over the repositories easily. You
         * typically don't need that for other modules. But, if you need, you can
         * implement the DbContext interface of the needed module and use ReplaceDbContext
         * attribute just like IIdentityProDbContext and ISaasDbContext.
         *
         * More info: Replacing a DbContext of a module ensures that the related module
         * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
         */

        // Identity
        public DbSet<IdentityUser> Users { get; set; }
        public DbSet<IdentityRole> Roles { get; set; }
        public DbSet<IdentityClaimType> ClaimTypes { get; set; }
        public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
        public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
        public DbSet<IdentityLinkUser> LinkUsers { get; set; }

        // SaaS
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Edition> Editions { get; set; }
        public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

        #endregion

        public AbpMvcDbContext(DbContextOptions<AbpMvcDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Include modules to your migration db context */

            builder.ConfigurePermissionManagement();
            builder.ConfigureSettingManagement();
            builder.ConfigureBackgroundJobs();
            builder.ConfigureAuditLogging();
            builder.ConfigureIdentityPro();
            builder.ConfigureIdentityServer();
            builder.ConfigureFeatureManagement();
            builder.ConfigureLanguageManagement();
            builder.ConfigurePayment();
            builder.ConfigureSaas();
            builder.ConfigureTextTemplateManagement();
            builder.ConfigureBlobStoring();

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(AbpMvcConsts.DbTablePrefix + "YourEntities", AbpMvcConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});
            if (builder.IsHostDatabase())
            {

            }
            if (builder.IsHostDatabase())
            {
                builder.Entity<Author>(b =>
    {
        b.ToTable(AbpMvcConsts.DbTablePrefix + "Authors", AbpMvcConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.Name).HasColumnName(nameof(Author.Name)).HasMaxLength(AuthorConsts.NameMaxLength);
        b.Property(x => x.BirthDate).HasColumnName(nameof(Author.BirthDate));
        b.Property(x => x.ShortBio).HasColumnName(nameof(Author.ShortBio));
    });

            }
            if (builder.IsHostDatabase())
            {
                builder.Entity<Book>(b =>
    {
        b.ToTable(AbpMvcConsts.DbTablePrefix + "Books", AbpMvcConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.Name).HasColumnName(nameof(Book.Name)).HasMaxLength(BookConsts.NameMaxLength);
        b.Property(x => x.Type).HasColumnName(nameof(Book.Type)).HasMaxLength(BookConsts.TypeMaxLength);
        b.Property(x => x.PublishDate).HasColumnName(nameof(Book.PublishDate));
        b.Property(x => x.Price).HasColumnName(nameof(Book.Price));
        b.HasOne<Author>().WithMany().HasForeignKey(x => x.AuthorId);
    });

            }
        }
    }
}
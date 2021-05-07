using Volo.Abp.Identity;

namespace abpMvc
{
    public static class abpMvcConsts
    {
        public const string DbTablePrefix = "App";
        public const string DbSchema = null;
        public const string AdminEmailDefaultValue = IdentityDataSeedContributor.AdminEmailDefaultValue;
        public const string AdminPasswordDefaultValue = IdentityDataSeedContributor.AdminPasswordDefaultValue;
    }
}

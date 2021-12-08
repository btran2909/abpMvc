namespace AbpMvc.Permissions
{
    public static class AbpMvcPermissions
    {
        public const string GroupName = "AbpMvc";

        public static class Dashboard
        {
            public const string DashboardGroup = GroupName + ".Dashboard";
            public const string Host = DashboardGroup + ".Host";
            public const string Tenant = DashboardGroup + ".Tenant";
        }

        //Add your own permission names. Example:
        //public const string MyPermission1 = GroupName + ".MyPermission1";

        public class Books
        {
            public const string Default = GroupName + ".Books";
            public const string Edit = Default + ".Edit";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class Authors
        {
            public const string Default = GroupName + ".Authors";
            public const string Edit = Default + ".Edit";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }
    }
}
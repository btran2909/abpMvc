namespace AbpMvc.Authors
{
    public static class AuthorConsts
    {
        private const string DefaultSorting = "{0}Name asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "Author." : string.Empty);
        }

        public const int NameMinLength = 0;
        public const int NameMaxLength = 36;
    }
}
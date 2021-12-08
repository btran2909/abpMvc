namespace AbpMvc.Books
{
    public static class BookConsts
    {
        private const string DefaultSorting = "{0}Name asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "Book." : string.Empty);
        }

        public const int NameMinLength = 0;
        public const int NameMaxLength = 36;
        public const int TypeMinLength = 0;
        public const int TypeMaxLength = 2;
    }
}
using AbpMvc.Authors;

namespace AbpMvc.Books
{
    public class BookWithNavigationProperties
    {
        public Book Book { get; set; }

        public Author Author { get; set; }
        
    }
}
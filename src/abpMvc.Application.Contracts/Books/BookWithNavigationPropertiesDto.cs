using AbpMvc.Authors;

using System;
using Volo.Abp.Application.Dtos;

namespace AbpMvc.Books
{
    public class BookWithNavigationPropertiesDto
    {
        public BookDto Book { get; set; }

        public AuthorDto Author { get; set; }

    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace AbpMvc.Books
{
    public class BookCreateDto
    {
        [StringLength(BookConsts.NameMaxLength, MinimumLength = BookConsts.NameMinLength)]
        public string Name { get; set; }
        [Range(BookConsts.TypeMinLength, BookConsts.TypeMaxLength)]
        public int Type { get; set; }
        public DateTime? PublishDate { get; set; }
        public float Price { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace AbpMvc.Authors
{
    public class AuthorCreateDto
    {
        [StringLength(AuthorConsts.NameMaxLength, MinimumLength = AuthorConsts.NameMinLength)]
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string ShortBio { get; set; }
    }
}
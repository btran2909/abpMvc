using Volo.Abp.Application.Dtos;
using System;

namespace AbpMvc.Authors
{
    public class GetAuthorsInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public string Name { get; set; }
        public DateTime? BirthDateMin { get; set; }
        public DateTime? BirthDateMax { get; set; }
        public string ShortBio { get; set; }

        public GetAuthorsInput()
        {

        }
    }
}
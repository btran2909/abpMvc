using Volo.Abp.Application.Dtos;
using System;

namespace AbpMvc.Books
{
    public class GetBooksInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public string Name { get; set; }
        public int? TypeMin { get; set; }
        public int? TypeMax { get; set; }
        public DateTime? PublishDateMin { get; set; }
        public DateTime? PublishDateMax { get; set; }
        public float? PriceMin { get; set; }
        public float? PriceMax { get; set; }

        public GetBooksInput()
        {

        }
    }
}
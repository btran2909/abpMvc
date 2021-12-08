using System;
using Volo.Abp.Application.Dtos;

namespace AbpMvc.Books
{
    public class BookDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public int Type { get; set; }
        public DateTime? PublishDate { get; set; }
        public float Price { get; set; }
    }
}
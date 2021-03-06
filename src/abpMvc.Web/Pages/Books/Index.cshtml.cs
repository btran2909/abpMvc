using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using AbpMvc.Books;
using AbpMvc.Shared;

namespace AbpMvc.Web.Pages.Books
{
    public class IndexModel : AbpPageModel
    {
        public string NameFilter { get; set; }
        public int? TypeFilterMin { get; set; }

        public int? TypeFilterMax { get; set; }
        public DateTime? PublishDateFilterMin { get; set; }

        public DateTime? PublishDateFilterMax { get; set; }
        public float? PriceFilterMin { get; set; }

        public float? PriceFilterMax { get; set; }
        [SelectItems(nameof(AuthorLookupList))]
        public Guid? AuthorIdFilter { get; set; }
        public List<SelectListItem> AuthorLookupList { get; set; } = new List<SelectListItem>
        {
            new SelectListItem(string.Empty, "")
        };

        private readonly IBooksAppService _booksAppService;

        public IndexModel(IBooksAppService booksAppService)
        {
            _booksAppService = booksAppService;
        }

        public async Task OnGetAsync()
        {
            AuthorLookupList.AddRange((
                    await _booksAppService.GetAuthorLookupAsync(new LookupRequestDto
                    {
                        MaxResultCount = LimitedResultRequestDto.MaxMaxResultCount
                    })).Items.Select(t => new SelectListItem(t.DisplayName, t.Id.ToString())).ToList()
            );

            await Task.CompletedTask;
        }
    }
}
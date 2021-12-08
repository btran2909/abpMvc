using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using AbpMvc.Authors;

namespace AbpMvc.Web.Pages.Authors
{
    public class EditModalModel : AbpMvcPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public AuthorUpdateDto Author { get; set; }

        private readonly IAuthorsAppService _authorsAppService;

        public EditModalModel(IAuthorsAppService authorsAppService)
        {
            _authorsAppService = authorsAppService;
        }

        public async Task OnGetAsync()
        {
            var author = await _authorsAppService.GetAsync(Id);
            Author = ObjectMapper.Map<AuthorDto, AuthorUpdateDto>(author);

        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _authorsAppService.UpdateAsync(Id, Author);
            return NoContent();
        }
    }
}
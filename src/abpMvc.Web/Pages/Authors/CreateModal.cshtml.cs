using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AbpMvc.Authors;

namespace AbpMvc.Web.Pages.Authors
{
    public class CreateModalModel : AbpMvcPageModel
    {
        [BindProperty]
        public AuthorCreateDto Author { get; set; }

        private readonly IAuthorsAppService _authorsAppService;

        public CreateModalModel(IAuthorsAppService authorsAppService)
        {
            _authorsAppService = authorsAppService;
        }

        public async Task OnGetAsync()
        {
            Author = new AuthorCreateDto();
            await Task.CompletedTask;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _authorsAppService.CreateAsync(Author);
            return NoContent();
        }
    }
}
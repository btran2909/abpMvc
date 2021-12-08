using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AbpMvc.Books;

namespace AbpMvc.Web.Pages.Books
{
    public class CreateModalModel : AbpMvcPageModel
    {
        [BindProperty]
        public BookCreateDto Book { get; set; }

        private readonly IBooksAppService _booksAppService;

        public CreateModalModel(IBooksAppService booksAppService)
        {
            _booksAppService = booksAppService;
        }

        public async Task OnGetAsync()
        {
            Book = new BookCreateDto();
            await Task.CompletedTask;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _booksAppService.CreateAsync(Book);
            return NoContent();
        }
    }
}
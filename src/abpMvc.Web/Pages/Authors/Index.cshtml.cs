using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using AbpMvc.Authors;
using AbpMvc.Shared;

namespace AbpMvc.Web.Pages.Authors
{
    public class IndexModel : AbpPageModel
    {
        public string NameFilter { get; set; }
        public DateTime? BirthDateFilterMin { get; set; }

        public DateTime? BirthDateFilterMax { get; set; }
        public string ShortBioFilter { get; set; }

        private readonly IAuthorsAppService _authorsAppService;

        public IndexModel(IAuthorsAppService authorsAppService)
        {
            _authorsAppService = authorsAppService;
        }

        public async Task OnGetAsync()
        {

            await Task.CompletedTask;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Blogmenia.Core;
using Blogmenia.Data;
using Microsoft.Extensions.Options;

namespace Blogmenia.Areas.Admin.Pages.CustomCategory
{
    public class IndexModel : PageModel
    {
        private readonly Blogmenia.Data.BlogmeniaDbContext _context;
        private readonly IOptions<AppDefaultSetting> options;

        public IndexModel(Blogmenia.Data.BlogmeniaDbContext context, IOptions<AppDefaultSetting> options)
        {
            _context = context;
            this.options = options;
        }

        public IList<Categories> Categories { get;set; }

        public string  iBaseUrl { get; set; }
        public async Task OnGetAsync()
        {
            Categories = await _context.Categories.ToListAsync();

            iBaseUrl = options.Value.BaseUrl;
        }
    }
}

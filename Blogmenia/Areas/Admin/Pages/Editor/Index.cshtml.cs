using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Blogmenia.Core;
using Blogmenia.Data;

namespace Blogmenia.Areas.Admin.Pages.Editor
{
    public class IndexModel : PageModel
    {
        private readonly Blogmenia.Data.BlogmeniaDbContext _context;

        public IndexModel(Blogmenia.Data.BlogmeniaDbContext context)
        {
            _context = context;
        }

        public IList<Demos> Demos { get;set; }

        public async Task OnGetAsync()
        {
            Demos = await _context.Demos.ToListAsync();
        }
    }
}

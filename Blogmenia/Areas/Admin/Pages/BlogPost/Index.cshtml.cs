using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogmenia.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace Blogmenia.Areas.Admin.Pages.BlogPost
{
    public class IndexModel : PageModel
    {
        private readonly IOptions<AppDefaultSetting> options;

        public string iBaseUrl { get; set; }
        public IndexModel(IOptions<AppDefaultSetting> options)
        {
            this.options = options;
          
        }
        public void OnGet()
        {
            iBaseUrl = this.options.Value.BaseUrl;
        }
    }
}

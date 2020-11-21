using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogmenia.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace Blogmenia.Pages
{
    public class NotFoundModel : PageModel
    {
        private readonly IOptions<AppDefaultSetting> ioptions;

        [ViewData]
        public MetaTags MyMetaTags { get; set; }
       
        public NotFoundModel(IOptions<AppDefaultSetting> ioptions)
        {
            
            this.ioptions = ioptions;
        }
        public IActionResult OnGet()
        {
            MetaTags m = new MetaTags(ioptions);
            m.Title = "Not Found";
            m.Web_Url = ioptions.Value.BaseUrl + "/NotFound";
            m.Description = "The page not found";

            MyMetaTags = m;

            return Page();
        }
    }
}

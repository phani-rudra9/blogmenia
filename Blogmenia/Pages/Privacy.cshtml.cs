using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogmenia.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Blogmenia.Pages
{
    [AllowAnonymous]
    public class PrivacyModel : PageModel
    {
        private readonly IOptions<AppDefaultSetting> ioptions;

        public PrivacyModel(IOptions<AppDefaultSetting>  ioptions)
        {
            this.ioptions = ioptions;
        }
        [ViewData]
        public MetaTags MyMetaTags { get; set; }
        public IActionResult OnGet()
        {
            MetaTags m = new MetaTags(ioptions);
            m.Title = "Privacy";
            m.Web_Url =ioptions.Value.BaseUrl+ "/privacy";
            m.Description = "Codepedia.info makes sure that the privacy of all its registered users is secured. Codepedia.info is founded on the principle of helping people having the main focus on programming tutorial, sharing programming tips";

            MyMetaTags = m;

            return Page();
        }
    }
}

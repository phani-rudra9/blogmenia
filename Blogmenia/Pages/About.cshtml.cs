using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogmenia.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace Blogmenia.Pages
{
    [AllowAnonymous]
    public class AboutModel : PageModel
    {
        private readonly IOptions<AppDefaultSetting> ioptions;

        [ViewData]
        public MetaTags MyMetaTags { get; set; }

        public AboutModel(IOptions<AppDefaultSetting> ioptions)
        {
            this.ioptions = ioptions;
        }
        public IActionResult OnGet()
        {

            MetaTags metaTags = new MetaTags(ioptions);
            metaTags.Title = "About";
            metaTags.FeaturedImg = "";
            metaTags.Web_Url = ioptions.Value.BaseUrl+ "/about";
            metaTags.Description = "Myself Satinder Singh, lives in Bombay. I am atypical polyglot programmer. I have more than 5 years of experience in Microsoft.NET technologies. I started my career working on creating Web Application with  ASP.NET 2.0 and now exploring ASP.NET 4.5, ASP.NET MVC, and  ANGULARJS";

            MyMetaTags = metaTags;

            return Page();
            
            
        }
    }
}

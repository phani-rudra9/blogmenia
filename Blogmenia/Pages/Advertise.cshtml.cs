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
    public class AdvertiseModel : PageModel
    {
        private readonly IOptions<AppDefaultSetting> ioptions;

        [ViewData]
        public MetaTags MyMetaTags { get; set; }
        public AdvertiseModel(IOptions<AppDefaultSetting> ioptions)
        {
            this.ioptions = ioptions;
        }
        public IActionResult OnGet()
        {

            MetaTags metaTags = new MetaTags(ioptions);
            metaTags.Title = "Advertise";
            metaTags.FeaturedImg = "";
            metaTags.Web_Url = ioptions.Value.BaseUrl + "/Advertise";
            metaTags.Description = "How to Advertise of Codepedia.info. Codepedia.info is a programming blog maintained by Satinder Singh. Tutorials focused on Programming ASP.Net, C#, jQuery, AngularJs, Gridview, MVC, Ajax, Javascript, XML, MS SQL-Server, NodeJs, Web Design, Software, codepedia, facebook scripts, twitter API, facebook like, twitter scripts, form validation, hosting, form submit, validation, application development, software, free scripts";

            MyMetaTags = metaTags;

            return Page();


        }
    }
}

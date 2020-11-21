using System.Collections.Generic;
using System.Text;
using Blogmenia.Core;
using Blogmenia.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace Blogmenia.Pages
{
    [AllowAnonymous]
    public class NikiMapModel : PageModel
    {
        private readonly IRepositoryData repositoryData;
        private readonly IOptions<AppDefaultSetting> options;

        public NikiMapModel(IRepositoryData repositoryData, IOptions<AppDefaultSetting> options)
        {
            this.repositoryData = repositoryData;
            this.options = options;
        }

        public IEnumerable<Post> PostList { get; set; }
        public IEnumerable<Sitemaping> PagesList { get; set; }
        public IActionResult OnGet()
        {
            PostList = repositoryData.GetAllPost();
            PagesList = repositoryData.GetAllSiteMapPages();


            string domainName = options.Value.BaseUrl;
            StringBuilder sb = new StringBuilder();
            sb.Append("<?xml version='1.0' encoding='UTF-8' ?><urlset xmlns = 'http://www.sitemaps.org/schemas/sitemap/0.9'>");


            foreach (var item in PagesList)
            {
                sb.Append("<url><loc>" + item.URl + "</loc><lastmod>" + item.ModificationDate + "</lastmod><priority>" + item.Priority + "</priority></url>");
            }

            foreach (var item in PostList)
            {
                sb.Append("<url><loc>" + domainName + item.Slug + "</loc><lastmod>" + item.ModifiedDate + "</lastmod><priority>0.7</priority></url>");
            }
            sb.Append("</urlset>");


            return new ContentResult
            {
                ContentType = "application/xml",
                Content = sb.ToString(),
                StatusCode = 200
            };


        }
    }
}

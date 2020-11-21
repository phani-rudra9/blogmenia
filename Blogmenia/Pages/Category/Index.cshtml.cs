using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogmenia.Core;
using Blogmenia.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace Blogmenia.Pages.Category
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        private readonly IRepositoryData repositoryData;
        private readonly IOptions<AppDefaultSetting> ioptions;

        [ViewData]
        public MetaTags MyMetaTags { get; set; }


        public IEnumerable<Post> PostList { get; set; }
        public Categories categories { get; set; }

        public IEnumerable<Categories> categories_List { get; set; }

        public IndexModel(IRepositoryData repositoryData, IOptions<AppDefaultSetting> ioptions)
        {
            this.repositoryData = repositoryData;
            this.ioptions = ioptions;
        }

        public int prev_no { get; set; }
        public int next_no { get; set; }
        public string cat_url { get; set; }
        public string no_more_record { get; set; }

        public IActionResult OnGet(string Slug, int? pageIndex)
        {
            MetaTags metaTags = new MetaTags(ioptions);
            if (!string.IsNullOrEmpty(Slug))
            {
                if (pageIndex == null || pageIndex == 0)
                {
                    pageIndex = 1;
                }


                metaTags.Title = Slug + " page " + pageIndex.ToString();
                metaTags.FeaturedImg = "";
                metaTags.Web_Url = ioptions.Value.BaseUrl+ "/Category/" + Slug;
                metaTags.Description = "Category " + Slug;

                categories = new Categories();
                categories.Slug = Slug;

                prev_no = Convert.ToInt32(pageIndex) - 1;
                next_no = Convert.ToInt32(pageIndex) + 1;

                PostList = repositoryData.GetPost_BySlugType("CATEGORY", Slug, (int)pageIndex, 9);

                if (PostList.Count() == 0)
                {
                    no_more_record = "YES";
                }
            }
            else
            {
                categories_List = repositoryData.GetAllCategories();
                metaTags.Title = "List of Categories";
                metaTags.FeaturedImg = "";
                metaTags.Web_Url =ioptions.Value.BaseUrl+ "/Category/";
                metaTags.Description = "Categories";

            }

            MyMetaTags = metaTags;
            return Page();
        }
    }
}

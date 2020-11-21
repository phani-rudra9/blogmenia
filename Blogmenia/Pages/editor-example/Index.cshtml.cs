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

namespace Blogmenia.Pages.editor_example
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        private readonly IRepositoryData repositoryData;
        private readonly IOptions<AppDefaultSetting> option;

        public Demos demo { get; set; }
        public IEnumerable<Demos> demoList { get; set; }

        public IndexModel(IRepositoryData repositoryData, IOptions<AppDefaultSetting> option)
        {
            this.repositoryData = repositoryData;
            this.option = option;
        }

        [ViewData]
        public MetaTags MyMetaTags { get; set; }

        public IActionResult OnGet([FromQuery] int? id, string slug) {

            MetaTags m = new MetaTags(option);
            m.Title = "Demo list";
            m.Description = "Codepedia.info complete list of programming tutorials examples";


            if (id>=0) {
                demo = repositoryData.GetDemoById((int)id);
                m.Web_Url = option.Value.BaseUrl+ "/editor-example?id=" + id.ToString();
            }
           else if (string.IsNullOrEmpty(slug))
            {
                demoList = repositoryData.GetAllDemoList();
                m.Web_Url = option.Value.BaseUrl + "/editor-example";
            }
            else {

                demo = repositoryData.GetDemoBySlug(slug);
                m.Web_Url = option.Value.BaseUrl + "/editor-example/" + slug;
            }

            MyMetaTags = m;

            return Page();

        }
    }
}

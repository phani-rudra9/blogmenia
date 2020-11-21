using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogmenia.Core;
using Blogmenia.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blogmenia.Areas.Admin.Pages.Featured
{
    public class IndexModel : PageModel
    {
        private readonly IRepositoryData repositoryData;

        public IndexModel(IRepositoryData repositoryData)
        {
            this.repositoryData = repositoryData;
        }

        [BindProperty]
        public IEnumerable<Post> post { get; set; }
        public IActionResult OnGet()
        {
            var featuredPost = repositoryData.GetAllFeaturedPost();

            post = featuredPost;

            return Page();
        }
    }
}

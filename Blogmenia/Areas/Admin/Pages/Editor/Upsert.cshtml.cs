using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogmenia.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Blogmenia.Core;

namespace Blogmenia.Areas.Admin.Pages.Editor
{
    public class UpsertModel : PageModel
    {
        private readonly IRepositoryData repositoryData;

        [BindProperty]
        public Demos demos { get; set; }

        [TempData]
        public string Message { get; set; }
        public UpsertModel(IRepositoryData repositoryData)
        {
            this.repositoryData = repositoryData;
        }

        public IActionResult OnGet(int? DemoId)
        {

            if (DemoId == null)
            {
                return Page();
            }

            demos = repositoryData.GetDemoById((int)DemoId);
            if (demos == null)
            {
                return NotFound();
            }

            return Page();
        }


        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }


            if (demos.DemoId > 0)
            {
                repositoryData.UpdateDemo(demos);
            }
            else
            {
                repositoryData.AddDemo(demos);
            }

            int temp = repositoryData.Commit();
            if (temp > 0)
            {
                Message = "Data saved successfully.";
            }
            else
            {
                Message = "Eoor occurs, pls try again later.";
            }
            return RedirectToPage("Upsert", new { DemoId = demos.DemoId });





        }
    }
}

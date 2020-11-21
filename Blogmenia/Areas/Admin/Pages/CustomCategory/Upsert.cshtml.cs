using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogmenia.Core;
using Blogmenia.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blogmenia.Areas.Admin.Pages.CustomCategory
{
    public class UpsertModel : PageModel
    {
        private readonly IRepositoryData repositoryData;

        [BindProperty]
        public Categories Categories { get; set; }

        [TempData]
        public string Message { get; set; }
        public UpsertModel(IRepositoryData repositoryData)
        {
            this.repositoryData = repositoryData;

        }

        public IActionResult OnGet(int? CategoryId)
        {
            Categories = new Categories();
            if (CategoryId == null)
            {
                //   PopulateCategoryDropDownList(db);
                return Page();
            }

            Categories = repositoryData.GetCategories_ById((int)CategoryId);

            if (Categories == null)
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

            if (Categories.CategoryId > 0)
            {
                repositoryData.UpdateCategory(Categories);
            }
            else
            {
                repositoryData.AddCategory(Categories);
            }

            int temp = repositoryData.Commit();
            if (temp > 0)
            {
                Message = "Category " + Categories.Name + " is saved successfully.";
            }
            else
            {
                Message = "Error occurs, pls try again later.";
            }
            return RedirectToPage("Upsert", new { CategoryId = Categories.CategoryId });
        }
    }
}
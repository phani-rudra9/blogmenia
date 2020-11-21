using Blogmenia.Core;
using Blogmenia.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogmenia.Areas.Admin.Pages.BlogPost
{
    public class CategoryList: PageModel
    {
      
        public SelectList CategoryNameSL { get; set; }

        public void PopulateCategoryDropDownList(BlogmeniaDbContext db,
           object selectedDepartment = null)
        {
           


            var query = from d in db.Categories
                           orderby d.Name
                           select d;

            CategoryNameSL = new SelectList(query.AsNoTracking()  , "CategoryId", "Name", selectedDepartment);


        }
    }
}

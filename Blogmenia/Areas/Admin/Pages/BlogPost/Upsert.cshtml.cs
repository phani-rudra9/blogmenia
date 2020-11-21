using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Blogmenia.Core;
using Blogmenia.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.FileProviders;

namespace Blogmenia.Areas.Admin.Pages.BlogPost
{
    public class UpsertModel : CategoryList
    {        
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IRepositoryData repositoryData;
        private readonly BlogmeniaDbContext db;

        public UpsertModel(IWebHostEnvironment webHostEnvironment, IRepositoryData repositoryData, BlogmeniaDbContext db)
        {
            this.repositoryData = repositoryData;
            this.webHostEnvironment = webHostEnvironment;
            this.db = db;
        }

        public class SelectListItem
        {
            public string Text { get; set; }
            public string Value { get; set; }
            public bool Selected { get; set; }
        }

        [TempData]
        public string Message { get; set; }

        [BindProperty]
        public Post Post { get; set; }

        [BindProperty]
        public IEnumerable<SelectListItem> CategoryOption { get; set; }

        [BindProperty]
        public IFormFile PhotoUpload { get; set; }

        [BindProperty]
        public IFormFile MyUploader { get; set; }

        public IActionResult OnGet(int? Id)
        {
            Post = new Post();
            if (Id == null)
            {
                PopulateCategoryDropDownList(db);
                return Page();
            }

            Post = repositoryData.GetPostById((int)Id);
            if (Post == null)
            {
                return NotFound();
            }
            if (Post.PrimaryCategoryId > 0)
            {
                PopulateCategoryDropDownList(db, Post.PrimaryCategoryId);
            }
            else
            {
                PopulateCategoryDropDownList(db);
            }

            return Page();
        }

        public IActionResult OnPostMyUploader()
        {
            string imgUrl = string.Empty;

            if (MyUploader != null)
            {
                imgUrl = ProcessUploadedFile(MyUploader);
            }
            return new ObjectResult(new { url = imgUrl });
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {                
                return Page();
            }

            if (PhotoUpload != null)
            {
                Post.FeaturedImg = ProcessUploadedFile(PhotoUpload);
            }

            if (Post.Id > 0)
            {
                Post.ModifiedDate = DateTime.Now;
                repositoryData.UpdatePost(Post);               
            }
            else
            {
                repositoryData.AddPost(Post);
            }

            repositoryData.Commit();
            PopulateCategoryDropDownList(db);
            TempData["Message"] = "Post saved successfully!";
            return RedirectToPage("./Upsert", new { Id = Post.Id });
        }

        public IActionResult OnGetImageList()
        {

            var provider = new PhysicalFileProvider(webHostEnvironment.WebRootPath);
            var contents = provider.GetDirectoryContents(Path.Combine("mediaUpload", "article"));
            var X = contents.OrderBy(m => m.Name);

            //  var fileList = "";// contents.f
            return new JsonResult(X);
        }

        private string ProcessUploadedFile(IFormFile iFile)
        {
            string uniqueFileName = null;            
            string randomString = DateTime.Now.Ticks.ToString();
            if (iFile != null)
            {
                var fnName = Path.GetFileNameWithoutExtension(iFile.FileName);
                var fnExtn = Path.GetExtension(iFile.FileName);
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "mediaUpload");
                uniqueFileName = "article/" + fnName + "_" + randomString + fnExtn;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    iFile.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }

        public class ImageData
        {
            public string status { get; set; }
            public string url { get; set; }
        }

    }
}

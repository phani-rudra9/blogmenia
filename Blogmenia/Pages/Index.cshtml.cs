using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Blogmenia.Core;
using Blogmenia.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Blogmenia.Pages
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IRepositoryData repositoryData;
        private readonly IOptions<AppDefaultSetting> options;

        [ViewData]
        public MetaTags MyMetaTags { get; set; }


        public Post post { get; set; }

        //@ViewData["Post_Id"]
        [ViewData]
        public int PostID { get; set; }
        public IEnumerable<Post> HomePagePostList { get; set; }
        public IEnumerable<Comments> Comment { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IRepositoryData repositoryData, IOptions<AppDefaultSetting> options)
        {
            _logger = logger;
            this.repositoryData = repositoryData;
            this.options = options;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        [BindProperty]
        public Subscriber subscribe { get; set; }
        public class InputModel
        {
            [Required]
            [Display(Name = "name")]
            public string Name { get; set; }

            [Required]
            [Display(Name = "email-id")]
            [EmailAddress]
            public string EmailAddress { get; set; }
            public string Website { get; set; }

            [Required]
            [Display(Name = "comment")]
            public string CommentMsg { get; set; }
        }

        [BindProperty]
        public string LastUpdatedDate { get; set; }


        public void OnPostSubscribeTop()
        {

            //   post = repositoryData.GetPostBySlug(Slug);
            if (ModelState.IsValid)
            {
                var a = subscribe;
            }
            else
            {

            }
            //return Page();
        }

        public IActionResult OnGet(string Slug)
        {
            MetaTags metaTags = new MetaTags(options);
            if (!string.IsNullOrEmpty(Slug))
            {

                if (!(Slug.Contains(".jpg") && Slug.Contains(".png")))
                {

                    post = repositoryData.GetPostBySlug(Slug);
                    if (post == null)
                    {
                        return RedirectToPage("./NotFound");
                    }

                    PostID = post.Id;

                    Comment = repositoryData.GetCommentsByPostId(post.Id);

                    string WebDomainName = options.Value.BaseUrl;
                    metaTags.Title = string.IsNullOrEmpty(post.MetaTitle) ? post.Title : post.MetaTitle;
                    metaTags.FeaturedImg = "mediaUpload/" + post.FeaturedImg;
                    metaTags.Web_Url = WebDomainName + Slug;
                    metaTags.Description = post.MetaDescription;
                    metaTags.ModifyDate = post.ModifiedDate.ToString("s");
                    metaTags.PublishDate = post.PublishDate.ToString("s");
                    metaTags.Keywords = post.MetaKeyword;
                    metaTags.PrimaryCategory = post.PrimaryCategoryId.ToString();

                    LastUpdatedDate = post.ModifiedDate.ToString("MMMM") + " " + post.ModifiedDate.ToString("dd") + ", " + post.ModifiedDate.ToString("yyyy");
                }
            }
            else
            {
                HomePagePostList = repositoryData.GetHomePageList();

               
            }




            MyMetaTags = metaTags;
            return Page();
        }

        public IActionResult OnPostComment()
        {
            if (!ModelState.IsValid)
            {

            }
            return Page();
        }

        public IActionResult OnPostUpdateSubscriber()
        {
            if (!ModelState.IsValid)
            {

            }
            return Page();
        }


    }
}

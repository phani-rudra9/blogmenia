using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogmenia.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Blogmenia.Core;
using Microsoft.AspNetCore.Authorization;

namespace Blogmenia.Api
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : Controller
    {
        private readonly IRepositoryData repositoryData;

        public CommentsController(IRepositoryData repositoryData)
        {
            this.repositoryData = repositoryData;
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult OnPostComments(Comments comments) {

            var cmt_ip = HttpContext.Connection.RemoteIpAddress.ToString();

            comments.Status = "0";
            comments.AuthorIp = cmt_ip;
            comments.CommentDate = DateTime.Now;
            comments.CommentDateGmt = DateTime.Now.ToUniversalTime();

            repositoryData.AddComments(comments);
           int result= repositoryData.Commit();

            if (result > 0) {
                return Json(new { success = true, message = "Your comments added successfully" });
            }

            return Json(new { success = false, message = "Error while adding comments. Pls tyr again later." });
        }

    }
}

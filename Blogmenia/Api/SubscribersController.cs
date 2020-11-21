using Blogmenia.Core;
using Blogmenia.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;

namespace Blogmenia.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribersController : Controller
    {
        private readonly IRepositoryData repositoryData;

        public SubscribersController(IRepositoryData repositoryData)
        {
            this.repositoryData = repositoryData;
        }


        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddSubscriber(Subscriber subscriber)
        {

            var ip_address = HttpContext.Connection.RemoteIpAddress.ToString();
            subscriber.IpAddress = ip_address;

            if (string.IsNullOrEmpty(subscriber.Name))
            {
                subscriber.Name = "NA";
            }

            if (repositoryData.IsSubscriberExist(subscriber.EmailId))
            {
                return Json(new { success = false, message = "Emailid already subscribed." });

            }

            repositoryData.AddSubscriber(subscriber);
            repositoryData.Commit();

            return Json(new { success = true, message = "Thank you for subscribing us." });

            //return new ContentResult
            //{
            //    StatusCode = 200,
            //    ContentType = "application/xml",
            //    Content = strContent,

            //};
        }

        [Authorize]
        [HttpGet]
        [ValidateAntiForgeryToken]
        public IActionResult GetSubscriber()
        {
           return Json(new { data = repositoryData.GetAllSubscriber() });
        }
    }
}

using Microsoft.AspNetCore.Identity;

namespace Blogmenia
{
    public class ApplicationUser : IdentityUser
    {
        public string WebsiteURL { get; set; }
    }
}

using System;
using Blogmenia;
using Blogmenia.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Blogmenia.Areas.Identity.IdentityHostingStartup))]
namespace Blogmenia.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<BlogmeniaContext>(options =>
                    options.UseMySql(
                        context.Configuration.GetConnectionString("BlogmeniaContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options => {
                    options.SignIn.RequireConfirmedAccount = true;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength=1;
                }).AddEntityFrameworkStores<BlogmeniaContext>();



                //services.AddDefaultIdentity<ApplicationUser>(options =>
                //{
                //    options.SignIn.RequireConfirmedEmail = true;
                //    options.Password.RequireNonAlphanumeric = false;
                //    options.Password.RequireUppercase = false;
                //    options.Password.RequireLowercase = false;
                //    options.Password.RequireDigit = false;
                //}).AddEntityFrameworkStores<BlogmeniaContext>();
            });
        }
    }
}
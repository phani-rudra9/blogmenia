using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogmenia.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Authorization;
using Blogmenia.Core;

namespace Blogmenia
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var AppDefaultSetting = Configuration.GetSection("AppDefaultSetting");
            services.Configure<AppDefaultSetting>(AppDefaultSetting);

            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
                options.Providers.Add<BrotliCompressionProvider>();
                options.Providers.Add<GzipCompressionProvider>();
                // options.Providers.Add<CustomCompressionProvider>();
                options.MimeTypes =
                    ResponseCompressionDefaults.MimeTypes.Concat(
                        new[] { "text/xml",
                            "text/plain",
                            "text/css",
                            "application/javascript",
                            "text/html",
                            "application/xml",
                            "text/xml",
                            "application/json",
                            "text/json"
                        });
            });
            // services.AddAntiforgery();
            services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
            services.AddDbContext<BlogmeniaDbContext>(
                option => option.UseMySql(Configuration.GetConnectionString("DefaultConnection")).EnableSensitiveDataLogging()
                // o => o.UseMySql(Configuration.GetConnectionString("asas"))
                );

            //services.AddDefaultIdentity<ApplicationUser>(options =>
            //{
            //    options.SignIn.RequireConfirmedEmail = true;
            //    options.Password.RequireNonAlphanumeric = false;
            //    options.Password.RequireUppercase = false;
            //    options.Password.RequireLowercase = false;
            //    options.Password.RequireDigit = false;
            //}).AddEntityFrameworkStores<BlogmeniaContext>();

            //services.AddScoped<IPostData, PostData>();
            //services.AddScoped<ICommentData, CommentData>();
            services.AddScoped<IRepositoryData, RepositoryData>();
            services.AddControllersWithViews();

            services.AddRazorPages(options =>
            {
                options.Conventions.AddPageRoute("/NikiMap", "NikiMap.xml");

            }).AddMvcOptions(o => o.Filters.Add(new AuthorizeFilter()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseResponseCompression();
            app.UseHttpsRedirection();
            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = (context) =>
                {
                    var headers = context.Context.Response.GetTypedHeaders();
                    headers.CacheControl = new CacheControlHeaderValue
                    {
                        Public = true,
                        MaxAge = TimeSpan.FromDays(365)
                    };
                }
            });

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });
        }
    }
}

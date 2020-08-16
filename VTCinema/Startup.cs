using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace VTCinema
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDistributedMemoryCache();
            services.AddMemoryCache();
            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                // Make the session cookie essential
                options.Cookie.IsEssential = true;
            });

            services.AddHttpContextAccessor();
            services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();
            //  app.UseHttpContextItemsMiddleware();
            app.UseAuthentication();
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Failed to Find Route");
            //});

            app.UseMvc(routes =>
            {
                routes
                .MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}")
               .MapRoute(
                    name: "Consult-Service",
                    template: "Consult/Service/{controller}/{action}/{id?}")
                ;

            });

            //routes.MapRoute(
            //    name: "AdminSubForder",
            //    url: "admin/{controller}/{action}/{id}",
            //    defaults: new { controller = "Index", action = "Index", id = "" }
            //);
            //routes.MapMvcAttributeRoutes();

        }
    }
}

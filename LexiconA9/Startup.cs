using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconA9
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(20);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );
                endpoints.MapControllerRoute(
                    name: "FeverCheck",
                    pattern: "FeverCheck",
                    defaults: new { controller = "Doctor", action = "FeverCheck" }
                    );
                endpoints.MapControllerRoute(
                    name: "GuessingGame",
                    pattern: "GuessingGame",
                    defaults: new { controller = "GuessingGame", action = "Index" }
                    );
                endpoints.MapControllerRoute(
                    name: "Persons",
                    pattern: "Persons",
                    defaults: new { controller = "PersonController", action = "Index" }
                    );
                endpoints.MapControllerRoute(
                    name: "Ajax",
                    pattern: "{controller=Ajax}/{action=Index}/{id?}"
                    //defaults: new { controller = "Ajax", action = "Index" }
                    );
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using static WEB_hw3.MyMiddleware;

namespace WEB_hw3
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
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Map("/home", home =>
            {
                home.Map("/Task1", Task1);
                home.Map("/Task2", Task2);
                home.Map("/Task3", Task3);
                home.Map("/Task4", Task4);
            });
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private static void Task1(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            { 
                await context.Response.WriteAsync("Hello World!"); 
            });
        }

        private static void Task2(IApplicationBuilder app)
        {
            int a = 13;
            int d = 16;
            int last = 223;
            double S = 0;
            app.Use(async (context, next) =>
            {
                S = last * (2 * a + (last - 1) * d) / 2;
                await next.Invoke();
            });
            
            app.Run(async (context) =>
            { 
                await context.Response.WriteAsync($"S = {S}");
            });
        }

        private static void Task3(IApplicationBuilder app)
        {
            double g = 9.80666;
            double l = 10;
            double T = 0;
            
            app.Use(async (context, next) =>
            {
                T = 2 * Math.PI * Math.Sqrt((l / g));
                await next.Invoke();
            });
            
            app.Run(async (context) =>
            { 
                await context.Response.WriteAsync($"T = {T}");
            });
        }

        private static void Task4(IApplicationBuilder app)
        {
            app.UseMyMiddleware();
        }
    }
}
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mission09_b2256.Models;
using Microsoft.AspNetCore.Http;

namespace Mission09_b2256
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
            services.AddDbContext<Models.BookstoreContext>(options =>
                options.UseSqlite("Data Source=Bookstore.sqlite"));
            services.AddScoped<IBookRepository, EFBookRepository>();
            services.AddScoped<IPurchaseRepository, EFPurchaseRepository>();
            services.AddRazorPages();
            services.AddHttpContextAccessor();

            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddScoped(x => SessionBasket.GetBasket(x));
            services.AddSingleton<HttpContextAccessor, HttpContextAccessor>();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("typepage", "{cateGory}/Page_{pageNum}", new { Controller = "Home", action = "Index" });
                endpoints.MapControllerRoute("Paging", "Page_{pageNum}", new { Controller = "Home", action = "Index", pageNum = 1 });

                endpoints.MapControllerRoute("type", "{projectType}", new { Controller = "Home", action = "Index", pageNum = 1 });
                //This here makes it so we kind of have a label for our pages
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
          

            
        }
    }
}

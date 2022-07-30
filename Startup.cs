using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using AFS_.NET_Developer_Test.InfraStructure;
using AFS_.NET_Developer_Test.Repository.Interfaces;
using AFS_.NET_Developer_Test.Repository.BusinessClasses;
namespace AFS_.NET_Developer_Test
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddControllersWithViews();
            services.AddDbContext<InfraStructure.ProjectContext>(options =>
                  options.UseSqlServer(
                      Configuration.GetConnectionString("DefaultConnections")));
            services.AddHttpClient();

            services.AddScoped(typeof(IRepo<>),typeof(RepoService<>));
            services.AddScoped<ILeetSpeak, LeetSpeakService>();
            services.AddScoped<IJQuery, JQueryService>();


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
             name: "Home",
              pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();

            });
        }
    }
}

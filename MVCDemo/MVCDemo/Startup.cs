using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MVCDemo.DataAccess;
using MVCDemo.Models;
using MVCDemo.Repositories;

namespace MVCDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // gets populated for you based on appsettings.json
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


            // whenever anyone needs an IMovieRepo, construct a MovieRepoDB for them
            services.AddScoped<IMovieRepo, MovieRepoDB>();
            // when anybody wants dbcontext MovieDBContext, get one
            // using sql server and a connection string found in appsettings.json (aka Configuration)
            services.AddDbContext<MovieDBContext>(optionsBulider => optionsBulider.UseSqlServer(Configuration.GetConnectionString("MoviesCodeFirstDB")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseCookiePolicy();

            // here in startup.configure is our global convention routing
            app.UseMvc(routes =>
            {

                routes.MapRoute(
                    name: "cast",
                    template: "Actors/{name}",
                    defaults: new { controller = "Cast", action = "Index" });
                
                // routes in order: first that matches is implemented
                // one route is pre-defined
                // always base URL (s/t like https://localhost:####/
                //  we ignore this part
                // this route says everything before the first slash is the controller
                // everything before the next slash is understood as the name of the action method
                // everything after that is put into a route parameter called id
                // every route needs to set controller and action in some way
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                // no id is fine (optional, ?)
                // no action, defaults to "Index"
                // no controller defaults to "Home"
            });
        }
    }
}

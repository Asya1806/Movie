using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kanema.Models;
using Kanema.Models.Movies;
using Kanema.Models.Users;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Kanema
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
            //services.AddDbContext<MovieContext>(options =>
            //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<UserContext>(options => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=KanemaUserDB;Trusted_Connection=True;"));
            //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<MovieContext>(options => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Movies;Trusted_Connection=True;"));


            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IMovieService, MovieService>();

            services.AddTransient<AccountValidator>();

            services.AddSession();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options => //CookieAuthenticationOptions
            {
                //options.Cookie.Name = "KanemaAuthCookie";
                //options.ExpireTimeSpan = TimeSpan.FromHours(2);
                //options.LoginPath = "/Account/Login";
                options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
            });

            

            // встраиваем сервис AgeHandler
            //services.AddTransient<IAuthorizationHandler, AgeHandler>();

            //services.AddAuthorization(opts => {
            //    // устанавливаем ограничение по возрасту
            //    opts.AddPolicy("AgeLimit",
            //        policy => policy.Requirements.Add(new AgeRequirement(18)));
            //});

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();

            //    //app.KanemaExseptionMiddleware();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //}
            app.UseDeveloperExceptionPage();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Movies}/{action=Index}");
            });
        }
    }
}

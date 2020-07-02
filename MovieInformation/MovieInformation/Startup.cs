using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using MovieInformation.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovieInformation.Models;
using MovieInformation.Services.ClassImp;
using MovieInformation.Services.Interfaces;

namespace MovieInformation
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
            // get config email : 
            var emailConfig = Configuration
                .GetSection("EmailConfiguration")
                .Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);
            //
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<MovieInformationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddAuthentication().AddCookie()
                .AddFacebook(facebookOptions =>
            {
                facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
                facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
                facebookOptions.AccessDeniedPath = "/Home";
                facebookOptions.SaveTokens = true;
            })
                //.AddGoogle(googleOptions =>
                //{
                //    IConfigurationSection googleAuthNSection = Configuration.GetSection("Authentication:Google");
                //    googleOptions.ClientId = googleAuthNSection["ClientId"];
                //    googleOptions.ClientSecret = googleAuthNSection["ClientSecret"];
                //})
                //.AddZalo(zaloOptions =>
                //{
                //    IConfigurationSection zaloAuthSection = Configuration.GetSection("Authentication:Zalo");
                //    zaloOptions.ClientId = zaloAuthSection["ClientId"];
                //    zaloOptions.ClientSecret = zaloAuthSection["ClientSecret"];

                //})
                //.AddMicrosoftAccount(microsoftOptions =>
                //{
                //    IConfigurationSection microsoftAuthNSection = Configuration.GetSection("Authentication:Microsoft");
                //    microsoftOptions.ClientId = microsoftAuthNSection["ClientId"];
                //    microsoftOptions.ClientSecret = microsoftAuthNSection["ClientSecret"];
                //})
                ;
            services.AddHttpClient<IMovieService, MovieService>(client =>
            {
                client.BaseAddress=new Uri("https://api.themoviedb.org/3/");
            });
            services.AddHttpClient<ISearchService, SearchService>(client =>
            {
                client.BaseAddress = new Uri("https://api.themoviedb.org/3/");
            });
            services.AddHttpClient<IGenreService, GenreService>(client =>
            {
                client.BaseAddress = new Uri("https://api.themoviedb.org/3/");
            });
            services.AddHttpClient<IUserSessionService, UserSessionService>(client =>
            {
                client.BaseAddress = new Uri("https://api.themoviedb.org/3/");
            });
            services.AddScoped<IPaymentPaypalService, PaymentPaypal>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}

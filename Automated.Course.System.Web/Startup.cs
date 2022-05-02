using Automated.Course.System.BLL.Interfaces;
using Automated.Course.System.BLL.Services;
using Automated.Course.System.DAL.EF;
using Automated.Course.System.DAL.Entities;
using Automated.Course.System.DAL.Interfaces;
using Automated.Course.System.DAL.Repositories;
using Automated.Course.System.Settings.Extensions;
using Automated.Course.System.Web.Mapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace Automated.Course.System.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration _configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            var section = _configuration.GetSection(nameof(AppSettings));
            var appSettings = section.Get<AppSettings>();
            services.AddSingleton(appSettings);

            services.AddDbContext<CourseContext>();
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<CourseContext>();

            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<ILanguageService, LanguageService>();

            services.AddAutoMapper(typeof(AppMappingProfile));


            services.AddAuthentication()
              .AddOAuth("VK", "VKontakte", config =>
              {
                  config.ClientId = _configuration["Authentication:VK:AppId"];
                  config.ClientSecret = _configuration["Authentication:VK:AppSecret"];
                  config.ClaimsIssuer = "VKontakte";
                  config.CallbackPath = new PathString("/signin-vkontakte-token");
                  config.AuthorizationEndpoint = "https://oauth.vk.com/authorize";
                  config.TokenEndpoint = "https://oauth.vk.com/access_token";
                  config.Scope.Add("email");
                  config.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "user_id");
                  config.ClaimActions.MapJsonKey(ClaimTypes.Email, "email");
                  config.SaveTokens = true;
                  config.Events = new OAuthEvents
                  {
                      OnCreatingTicket = context =>
                      {
                          context.RunClaimActions(context.TokenResponse.Response.RootElement);
                          return Task.CompletedTask;
                      }
                  };
              });
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

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

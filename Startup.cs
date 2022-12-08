using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using spoti_stats.Models;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using static SpotifyAPI.Web.Scopes;

namespace spoti_stats
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
            _ = services.AddHttpContextAccessor();
            _ = services.AddSingleton(SpotifyClientConfig.CreateDefault());
            _ = services.AddScoped<SpotifyClientBuilder>();

            _ = services.AddAuthorization(options =>
            {
                options.AddPolicy("Spotify", policy =>
          {
              policy.AuthenticationSchemes.Add("Spotify");
              _ = policy.RequireAuthenticatedUser();
          });
            });
            _ = services
              .AddAuthentication(options =>
              {
                  options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
              })
              .AddCookie(options =>
              {
                  options.ExpireTimeSpan = TimeSpan.FromMinutes(0);
              })
              .AddSpotify(options =>
              {
                  options.ClientId = "4ae5c6f27b32487eab09768b4b7a24bb";
                  options.ClientSecret = "ae6e030d04a3425ca2dba86c2d0a3e19";
                  options.CallbackPath = "/Auth/callback";
                  options.SaveTokens = true;

                  List<string> scopes = new()
                  {
            UserReadEmail, UserTopRead
                };
                  options.Scope.Add(string.Join(",", scopes));
              });
            _ = services.AddRazorPages()
              .AddRazorPagesOptions(options =>
              {
                  _ = options.Conventions.AuthorizeFolder("/Stats/", "Spotify");
              });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            _ = env.IsDevelopment() ? app.UseDeveloperExceptionPage() : app.UseExceptionHandler("/Error");

            _ = app.UseHttpsRedirection();
            _ = app.UseStaticFiles();

            _ = app.UseRouting();

            _ = app.UseAuthentication();
            _ = app.UseAuthorization();

            _ = app.UseEndpoints(endpoints =>
            {
                _ = endpoints.MapRazorPages();
            });
        }
    }
}

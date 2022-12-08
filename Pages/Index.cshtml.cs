using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpotifyAPI.Web;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using spoti_stats.Models;
using System;
using System.Collections.Generic;
using static SpotifyAPI.Web.Scopes;
using Microsoft.AspNetCore.Server.HttpSys;

namespace spoti_stats.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}

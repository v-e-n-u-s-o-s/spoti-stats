using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using SpotifyAPI.Web;
using System.Threading.Tasks;

namespace spoti_stats.Models
{
    public class SpotifyClientBuilder
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly SpotifyClientConfig _spotifyClientConfig;

        public SpotifyClientBuilder(IHttpContextAccessor httpContextAccessor, SpotifyClientConfig spotifyClientConfig)
        {
            _httpContextAccessor = httpContextAccessor;
            _spotifyClientConfig = spotifyClientConfig;
        }

        public async Task<SpotifyClient> BuildClient()
        {
            string token = await _httpContextAccessor.HttpContext.GetTokenAsync("Spotify", "access_token");

            return new SpotifyClient(_spotifyClientConfig.WithToken(token));
        }
    }
}

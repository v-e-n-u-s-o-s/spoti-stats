using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using spoti_stats.Models;
using SpotifyAPI.Web;
using System.Threading.Tasks;

namespace spoti_stats.Pages.Stats
{
    public class IndexModel : PageModel
    {
        private readonly SpotifyClientBuilder _spotifyClientBuilder;
        public Paging<FullTrack> top_5_tracks { get; set; }

        public IndexModel(SpotifyClientBuilder spotifyClientBuilder)
        {
            _spotifyClientBuilder = spotifyClientBuilder;
        }

        public async Task OnGet()
        {
            var spotify = await _spotifyClientBuilder.BuildClient();

            top_5_tracks = await spotify.Personalization.GetTopTracks(new PersonalizationTopRequest { Limit = 3 });

        }
    }
}

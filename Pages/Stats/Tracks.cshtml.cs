using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using spoti_stats.Models;
using SpotifyAPI.Web;
using System.Threading.Tasks;

namespace spoti_stats.Pages.Stats
{
    public class TracksModel : PageModel
    {
        private readonly SpotifyClientBuilder _spotifyClientBuilder;
        public Paging<FullTrack> top_tracks { get; set; }

        public TracksModel(SpotifyClientBuilder spotifyClientBuilder)
        {
            _spotifyClientBuilder = spotifyClientBuilder;
        }

        public async Task OnGet()
        {
            var spotify = await _spotifyClientBuilder.BuildClient();

            top_tracks = await spotify.Personalization.GetTopTracks(new PersonalizationTopRequest { Limit = 100 });

        }
    }
}

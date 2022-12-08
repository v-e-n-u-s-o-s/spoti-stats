using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using spoti_stats.Models;
using SpotifyAPI.Web;
using System.Threading.Tasks;

namespace spoti_stats.Pages.Stats
{
    public class ArtistsModel : PageModel
    {
        private readonly SpotifyClientBuilder _spotifyClientBuilder;
        public Paging<FullArtist> top_artists { get; set; }
        
        public ArtistsModel(SpotifyClientBuilder spotifyClientBuilder)
        {
            _spotifyClientBuilder = spotifyClientBuilder;
        }

        public async Task OnGet()
        {
            var spotify = await _spotifyClientBuilder.BuildClient();

            top_artists = await spotify.Personalization.GetTopArtists(new PersonalizationTopRequest { Limit = 100 });

        }
    }
}

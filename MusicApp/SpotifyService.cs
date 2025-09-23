using SpotifyAPI.Web;
using Microsoft.Extensions.Configuration;

namespace MusicApp;

public class SpotifyService
{
    private readonly SpotifyClient _spotify;
    private readonly AppDbContext _dbContext;

    public SpotifyService(IConfiguration config, AppDbContext dbContext)
    {
        var spotifyConfig = SpotifyClientConfig.CreateDefault()
            .WithAuthenticator(new ClientCredentialsAuthenticator(
                config["Spotify:ClientId"],
                config["Spotify:ClientSecret"]));
        _spotify = new SpotifyClient(spotifyConfig);
        _dbContext = dbContext;
    }

    public async Task<List<Song>> SearchAndSaveTracksAsync(string query)
    {
        var search = await _spotify.Search.Item(new SearchRequest(SearchRequest.Types.Track, query));
        var songs = search.Tracks.Items.Select(t => new Song
        {
            Title = t.Name,
            Artist = string.Join(", ", t.Artists.Select(a => a.Name)),
            ExternalId = t.Id,
            PreviewUrl = t.PreviewUrl,
            Duration = (int?)t.DurationMs / 1000
        }).ToList();
        _dbContext.Songs.AddRange(songs);
        await _dbContext.SaveChangesAsync();
        return songs;
    }
}
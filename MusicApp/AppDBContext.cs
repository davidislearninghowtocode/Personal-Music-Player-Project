using Microsoft.EntityFrameworkCore;

namespace MusicApp;

public class AppDbContext : DbContext
{
    public DbSet<Song> Songs { get; set; } // Thêm các bảng khác nếu cần (Users, Playlists, etc.)

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=musicapp.db");
        }
    }
}

public class Song
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Artist { get; set; }
    public string ExternalId { get; set; }
    public string PreviewUrl { get; set; }
    public int? Duration { get; set; }
}
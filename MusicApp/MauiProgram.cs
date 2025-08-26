using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace MusicApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // Cấu hình để đọc appsettings.json
        builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        // Cấu hình logging
#if DEBUG
        builder.Logging.AddDebug();
#endif

        // Đăng ký dịch vụ
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite("Data Source=musicapp.db"));
        builder.Services.AddSingleton<SpotifyService>();

        return builder.Build();
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Telegram.Bot;
using WORLDGAMEDEVELOPMENT;


#region WORLDGAMEDEVELOPMENT

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(Configuration.APPSETTINGS_JSON, optional: false, reloadOnChange: true);

        IConfigurationRoot configuration = builder.Build();

        var appConfig = configuration.Get<AppConfig>();
        if (appConfig == null)
            return;

        var botClient = new TelegramBotClient(appConfig.BotKeyDebug);

        var dbContext = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>(), appConfig.ConnectionStrings[Configuration.CONNECTION_TEST]);
        var databaseService = new DatabaseService(appConfig, dbContext);

        await Console.In.ReadLineAsync();
    }
}

#endregion
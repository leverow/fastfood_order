using Telegram.Bot;

namespace fastfood_order.Services;
public class BotBackgroundService : BackgroundService
{
    private readonly ILogger<BotBackgroundService> _logger;
    private readonly TelegramBotClient _botClient;

    public BotBackgroundService(
        ILogger<BotBackgroundService> logger,
        TelegramBotClient botClient)
    {
        _logger = logger;
        _botClient = botClient;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var bot = await _botClient.GetMeAsync();

        _logger.LogInformation($"{bot.Username} ishga tushdi! :)");
    }
}
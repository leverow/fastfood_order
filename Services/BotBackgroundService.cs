using Telegram.Bot;
using Telegram.Bot.Polling;

namespace fastfood_order.Services;
public class BotBackgroundService : BackgroundService
{
    private readonly ILogger<BotBackgroundService> _logger;
    private readonly TelegramBotClient _botClient;
    private readonly IUpdateHandler _updateHandler;

    public BotBackgroundService(
        ILogger<BotBackgroundService> logger,
        TelegramBotClient botClient,
        IUpdateHandler updateHandler)
    {
        _logger = logger;
        _botClient = botClient;
        _updateHandler = updateHandler;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _botClient.StartReceiving(
            _updateHandler.HandleUpdateAsync,
            _updateHandler.HandlePollingErrorAsync,
            new ReceiverOptions()
            {
                ThrowPendingUpdates = true
            }, stoppingToken);

        var bot = await _botClient.GetMeAsync();
        _logger.LogInformation($"{bot.Username} bot is Started! :)");
    }
}
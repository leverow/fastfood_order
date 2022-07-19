using System.Globalization;
using Microsoft.Extensions.Localization;
using ProjectTg.Resources;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace fastfood_order.Services;

public partial class BotUpdateHandler : IUpdateHandler
{
    private readonly ILogger<BotUpdateHandler> _logger;
    private readonly IServiceScopeFactory _scopeFactory;
    private IStringLocalizer _localizer;
    private UserService _userService;

    public BotUpdateHandler(
        ILogger<BotUpdateHandler>  logger,
        IServiceScopeFactory scopeFactory)  
    {
        _logger = logger;
        _scopeFactory = scopeFactory;
    }

    public Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Error in the Bot! Message: {exception.Message})");
        return Task.CompletedTask;
    }

    public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        using var scope = _scopeFactory.CreateScope();

        _userService = scope.ServiceProvider.GetRequiredService<UserService>();

        var culture = await GetCultureForUser(update);
        CultureInfo.CurrentCulture = culture;
        CultureInfo.CurrentUICulture = culture;

        _localizer = scope.ServiceProvider.GetRequiredService<IStringLocalizer<BotLocalizer>>();

        var handler = update.Type switch
        {
            UpdateType.Message => HandleMessageAsync(botClient, update.Message, cancellationToken),
            UpdateType.EditedMessage => HandleEditMessageAsync(botClient, update.EditedMessage, cancellationToken),
            _ => HandleUnknowMessageAsync(botClient, update, cancellationToken)
        };

        try
        {
            await handler;
        }
        catch(Exception e)
        {
            await HandlePollingErrorAsync(botClient, e, cancellationToken);
        }
    }

    private async Task<CultureInfo> GetCultureForUser(Update update)
    {
        User? from = update.Type switch
        {
            UpdateType.Message => update?.Message?.From,
            UpdateType.EditedMessage => update?.EditedMessage?.From,
            UpdateType.CallbackQuery => update?.CallbackQuery?.From,
            UpdateType.InlineQuery => update?.InlineQuery?.From,
            _ => update?.Message?.From
        };
        var user = await _userService.GetUserAsync(from?.Id);

        return new CultureInfo(user?.LanguageCode ?? "uz-Uz");
    }

    private Task HandleUnknowMessageAsync(ITelegramBotClient botClient, Update? update, CancellationToken token)
    {
        _logger.LogInformation($"Update Type => {update?.Type}");

        return Task.CompletedTask;
    }
}
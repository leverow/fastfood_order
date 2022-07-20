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
            UpdateType.CallbackQuery => HandleCallBackQueryAsync(botClient, update.CallbackQuery, cancellationToken),
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

        var result = await _userService.AddUserAsync(new Entity.User()
        {
            FirstName = from.FirstName,
            LastName = from.LastName,
            // ChatId = update.Message.Chat.Id,
            UserId = from.Id,
            Username = from.Username,
            LanguageCode = from.LanguageCode,
            CreatedAt = DateTimeOffset.UtcNow,
            LastInteractionAt = DateTimeOffset.UtcNow
        });

        if(result.IsSuccess)
        {
            _logger.LogInformation($"New user successfully added: {from.Id}, Name: {from.FirstName}");
        }
        else
        {
            _logger.LogInformation($"User not added: {from.Id}, Error: {result.ErrorMessage}");
        }

        var language = await _userService.GetLanguageCodeAsync(from?.Id);

        return new CultureInfo(language ?? "uz-Uz");
    }

    private Task HandleUnknowMessageAsync(ITelegramBotClient botClient, Update? update, CancellationToken token)
    {
        _logger.LogInformation($"Update Type => {update?.Type}");

        return Task.CompletedTask;
    }
}
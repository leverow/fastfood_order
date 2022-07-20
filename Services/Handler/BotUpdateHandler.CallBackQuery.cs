using Telegram.Bot;
using Telegram.Bot.Types;

namespace fastfood_order.Services;

public partial class BotUpdateHandler
{
    private async Task HandleCallBackQueryAsync(ITelegramBotClient botClient, CallbackQuery? query, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(query);

        var from = query.From;
        
        _logger.LogInformation("Received CallbackQuery from {from.Firstname}: {query.Data}", from?.FirstName, query.Data);

        if(query?.Data == "sausage")
        {
            var result = await _userService.AddExtrasAsync(query.From.Id, sausage: 1);

            if(result.IsSuccess)
            {
                _logger.LogInformation($"New ExtraSausage successfully added by {query.From.Id}, Name: {query.From.FirstName}");
            }
            else
            {
                _logger.LogInformation($"Extra Sausage not added: {query.From.Id}, Error: {result.ErrorMessage}");
            }
        }
    }
}
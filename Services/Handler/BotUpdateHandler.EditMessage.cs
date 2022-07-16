using Telegram.Bot;
using Telegram.Bot.Types;

namespace fastfood_order.Services;

public partial class BotUpdateHandler
{
    private async Task HandleEditMessageAsync(ITelegramBotClient botClient, Message? message, CancellationToken token)
    {
        ArgumentNullException.ThrowIfNull(message);

        var from = message.From;
        _logger.LogInformation($"Name: {from?.FirstName}, Username: {from?.Username} => Message: {message.Text}");

        await botClient.SendTextMessageAsync(
            chatId: message.Chat.Id,
            text: "O'zgartirildi",
            cancellationToken: token
        );
    }
}
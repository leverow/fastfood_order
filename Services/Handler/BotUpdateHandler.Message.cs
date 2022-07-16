using System;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace fastfood_order.Services;

public partial class BotUpdateHandler
{
    private async Task HandleMessageAsync(ITelegramBotClient botClient, Message? message, CancellationToken token)
    {
        ArgumentNullException.ThrowIfNull(message);

        var from = message.From;
        _logger.LogInformation($"Nage - {from?.FirstName} Username{from?.Username} -> Message ({message.Text})");

        var handler = message.Type switch
        {
            MessageType.Text => HandlerTextMessageAsync(botClient, message, token),
            _ => HandleUnknownMessageAsync(botClient, message, token)
        };

        await handler;
    }

    private async Task HandlerTextMessageAsync(ITelegramBotClient botClient, Message message, CancellationToken token)
    {
        var chatId = message.Chat.Id;

        await botClient.SendTextMessageAsync(
            chatId,
            text: "ishlayapti",
            cancellationToken: token
        );
    }

    private async Task HandleUnknownMessageAsync(ITelegramBotClient botClient, Message message, CancellationToken token)
    {
        var chatId = message.Chat.Id;

        await botClient.SendTextMessageAsync(
            chatId,
            text: "Siz botga (Unknow message) jonatdingiz",
            cancellationToken: token
        );
    }

}
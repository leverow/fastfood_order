using System;
using fastfood_order.Services.Handler;
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

        var messageChatId = 0;

        if(message.Text == "/start")
        {
            await botClient.SendTextMessageAsync(
                chatId,
                text: "Tilni tanlang!",
                cancellationToken: token
            );

            Console.WriteLine($"{message.MessageId}");
            
        }

        if(message.Text == "uzbek")
        {
            await botClient.SendTextMessageAsync(
                chatId,
                text: "Ism familiyanginzni jo'nating!",
                cancellationToken: token
            );
            messageChatId = message.MessageId;
        }
        if(messageChatId+1 == message.MessageId)
        {
            Console.WriteLine($"{message.MessageId}");   
        }
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
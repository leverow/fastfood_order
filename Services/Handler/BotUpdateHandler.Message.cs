using System.Security.Cryptography;
using System;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using bot.Helpers;
using bot.Constants;

namespace fastfood_order.Services;

public partial class BotUpdateHandler
{
    private async Task HandleMessageAsync(ITelegramBotClient botClient, Message? message, CancellationToken token)
    {
        ArgumentNullException.ThrowIfNull(message);

        var from = message.From;
        _logger.LogInformation($"Name - {from?.FirstName} Username: {from?.Username} -> Message text: ({message.Text})");

        var handler = message.Type switch
        {
            MessageType.Text => HandlerTextMessageAsync(botClient, message, token),
            MessageType.Contact => HandlerContactMessageAsync(botClient, message, token),
            _ => HandleUnknownMessageAsync(botClient, message, token)
        };

        await handler;
    }

    private async Task<Task> HandlerContactMessageAsync(ITelegramBotClient botClient, Message message, CancellationToken token)
    {
        await CheckAndSaveContact(botClient,message,token);
        return Task.CompletedTask;
    }
    
    private async Task HandlerTextMessageAsync(ITelegramBotClient botClient, Message message, CancellationToken token)
    {
        var chatId = message.Chat.Id;
        
        var handler = message.Text switch
        {
            "/start" or "Til" => ChangeLanguage(botClient, message, token),
            "O'zbekcha" or "Русский" or "English" => MainButtons(botClient, message, token),
            "Biz haqimizda" => AboutUs(botClient, message, token),
            "Sozlamalar" => Settings(botClient, message, token),
            "Buyurtma berish" => Order(botClient, message, token),
            "Ortga" => Back(botClient, message, token),
            "Raqam" => GetNumber(botClient, message, token),
            _ => Task.CompletedTask
        };
        
        await handler;
    }
    public static async Task<Task> CheckAndSaveContact(ITelegramBotClient botClient, Message message, CancellationToken token)
    {

        if(!message.Contact.PhoneNumber.Contains("+998"))
        {
            // await botClient.SendTextMessageAsync(
            //     chatId: message.Chat.Id,
            //     text: "Telefon raqam formati noto`g`ri kiritildi.",
            //     replyMarkup: CreateContactRequestButton("Qaytadan telefon raqamni ulashish"),
            //     cancellationToken: token
            // );

            await botClient.SendTextMessageAsync(
            chatId: message.Chat.Id,
            text: $"Telefon raqam formati noto`g`ri kiritildi.",
            replyMarkup: MarkupHelpers.GetReplyKeyboardMarkup(MainContains.LanguageNames.Values.ToArray(), 3),
            parseMode: ParseMode.Html,
            cancellationToken: token);
        }
        else
        {
            await botClient.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: "Raqamingiz muvafaqqiyatli saqlandi",
                replyMarkup: new ReplyKeyboardRemove(),
                cancellationToken: token);

            await botClient.SendTextMessageAsync(
            chatId: message.Chat.Id,
            text: $"Asosiy",
            replyMarkup: MarkupHelpers.GetReplyKeyboardMarkup(MainContains.LanguageNames.Values.ToArray(), 3),
            parseMode: ParseMode.Html,
            cancellationToken: token);
        }
        return Task.CompletedTask;
    }
    private async Task HandleUnknownMessageAsync(ITelegramBotClient botClient, Message message, CancellationToken token)
    {
        var chatId = message.Chat.Id;

        _logger.LogInformation($"User send {message.Type} message!");
    }
}
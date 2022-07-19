using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using bot.Helpers;
using Microsoft.Extensions.Localization;

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
            MessageType.Location => HandlerLocationMessageAsync(botClient, message, token),
            _ => HandleUnknownMessageAsync(botClient, message, token)
        };

        await handler;
    }

    private async Task<Task> HandlerContactMessageAsync(ITelegramBotClient botClient, Message message, CancellationToken token)
    {
        await CheckAndSaveContact(botClient,message,token);
        return Task.CompletedTask;
    }

    private async Task<Task> HandlerLocationMessageAsync(ITelegramBotClient botClient, Message message, CancellationToken token)
    {
        await CheckAndSaveLocation(botClient,message,token);
        return Task.CompletedTask;
    }
    
    private async Task HandlerTextMessageAsync(ITelegramBotClient botClient, Message message, CancellationToken token)
    {
        var chatId = message.Chat.Id;
        var handler = message.Text switch
        {
            "/start" => HandleStartMessageAsync(botClient, message, token),
            "O'zbekcha 🇺🇿" or "Pусский 🇷🇺" or "English 🇺🇸" => HandleLanguageAsync(botClient, message, token),
            "Biz haqimizda" => AboutUs(botClient, message, token),
            "Sozlamalar" => Settings(botClient, message, token),
            "Buyurtma berish" => Order(botClient, message, token),
            "Ortga" => ReplyMarkupBackKeyboard(botClient, message, token),
            "Raqamni jo'natish" => GetNumber(botClient, message, token),
            "Americano hot dog" or "Classic hot dog" or "Double hot-dog" or "Meat hot-dog" or "Franch hot-dog" 
                => Foods(botClient, message, token),
            "Ichimliklar" => Drinks(botClient, message, token),
            "Haridni davom etish" => Order(botClient, message, token),
            "Davom etish" => FoodCount(botClient, message, token),
            "1" or "2" or "3" or "4" or "5" or "6" or "7" or "8" or "9" or "10"
                => ReadyFood(botClient, message, token),
            "Zakaz berish" => SendLocation(botClient, message, token),
            _ => Task.CompletedTask
        };
        
        await handler;
    }

    private async Task HandleStartMessageAsync(ITelegramBotClient botClient, Message message, CancellationToken token)
    {
        await ChangeLanguage(botClient,message,token);
    }

    public static async Task<Task> CheckAndSaveContact(ITelegramBotClient botClient, Message message, CancellationToken token)
    {

        // if(!message.Contact.PhoneNumber.Contains("+998"))
        // {

        //     await botClient.SendTextMessageAsync(
        //     chatId: message.Chat.Id,
        //     text: $"Telefon raqam formati noto`g`ri kiritildi.",
        //     parseMode: ParseMode.Html,
        //     cancellationToken: token);

        //     await GetNumber(botClient, message, token);
        // }
        // else
        // {}
            await botClient.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: "Zakaz haqida ma'luomt chiqadi va asosiy menuga qaytib ketadi",
                replyMarkup: MarkupHelpers.GetReplyKeyboardMarkup(MainMenu.Values.ToArray(), 3),
                cancellationToken: token);
        return Task.CompletedTask;
    }

    public static async Task<Task> CheckAndSaveLocation(ITelegramBotClient botClient, Message message, CancellationToken token)
    {
        await GetNumber(botClient, message, token);
        
        return Task.CompletedTask;
    }
    private async Task HandleLanguageAsync(ITelegramBotClient client, Message message, CancellationToken token)
    {
        var cultureString = LanguageNames.FirstOrDefault(v => v.Value == message.Text).Key;
        await _userService.UpdateLanguageCodeAsync(message.From.Id, cultureString);

        await client.DeleteMessageAsync(message.Chat.Id, message.MessageId, token);

        await MainButtons(client, message, token);
    }
    private Task HandleUnknownMessageAsync(ITelegramBotClient botClient, Message message, CancellationToken token)
    {
        var chatId = message.Chat.Id;

        _logger.LogInformation($"User send {message.Type} message!");

        return Task.CompletedTask;
    }
}
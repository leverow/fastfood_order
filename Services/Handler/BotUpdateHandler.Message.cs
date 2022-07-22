using System.Globalization;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using bot.Helpers;
using Microsoft.Extensions.Localization;
using Telegram.Bot.Types.ReplyMarkups;

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
        
        if(message.Text == _localizer["to-order"]) await MenuOfHotdogs(botClient,message,token);
        if(message.Text == _localizer["back"]) await ReplyMarkupBackKeyboard(botClient, message, token);
        if(message.Text == _localizer["send"]) await GetNumber(botClient, message, token);
        if(message.Text == _localizer["our-information"]) await AboutUs(botClient, message, token);
        if(message.Text == _localizer["settings"]) await Settings(botClient, message, token);
        if(message.Text == _localizer["continue-shopping"]) await MenuOfHotdogs(botClient, message, token);
        if(message.Text == _localizer["drinks"]) await Drinks(botClient, message, token);
        // if(message.Text == _localizer["next"]) await FoodCount(botClient, message, token);
        if(message.Text == _localizer["buy"]) await SendLocation(botClient, message, token);
        if(message.Text == _localizer["choose-language"]) await ChangeLanguage(botClient,message,token);
        
        var handler = message.Text switch
        {
            "/start" => HandleStartMessageAsync(botClient, message, token),
            "O'zbekcha 🇺🇿" or "Pусский 🇷🇺" or "English 🇺🇸" => HandleLanguageAsync(botClient, message, token),
            
            "Americano hot-dog 🌭" => Foods(botClient, message, token, 1),
            "Double hot-dog 🌭" => Foods(botClient, message, token, 2),
            "Franch hot-dog 🌭" => Foods(botClient, message, token, 3),
            "Meat hot-dog 🌭" => Foods(botClient, message, token, 4),
            "Classic hot-dog 🌭" => Foods(botClient, message, token, 5),

            _ => Task.CompletedTask
        };
        
        await handler;
    }

    private async Task HandleStartMessageAsync(ITelegramBotClient botClient, Message message, CancellationToken token)
    {
        await ChangeLanguage(botClient,message,token);
    }

    public async Task<Task> CheckAndSaveContact(ITelegramBotClient botClient, Message message, CancellationToken token)
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
        await MainButtons(botClient, message, token);

        return Task.CompletedTask;
    }

    public async Task<Task> CheckAndSaveLocation(ITelegramBotClient botClient, Message message, CancellationToken token)
    {
        await GetNumber(botClient, message, token);
        
        return Task.CompletedTask;
    }
    private async Task HandleLanguageAsync(ITelegramBotClient client, Message message, CancellationToken token)
    {
        var cultureString = LanguageNames.FirstOrDefault(v => v.Value == message.Text).Key;
        await _userService.UpdateLanguageCodeAsync(message?.From?.Id, cultureString);

        CultureInfo.CurrentCulture = new CultureInfo(cultureString);
        CultureInfo.CurrentUICulture = new CultureInfo(cultureString);

        // await client.DeleteMessageAsync(message.Chat.Id, message.MessageId, token);

        await MainButtons(client, message, token);
    }
    private Task HandleUnknownMessageAsync(ITelegramBotClient botClient, Message message, CancellationToken token)
    {
        var chatId = message.Chat.Id;

        _logger.LogInformation($"User send {message.Type} message!");

        return Task.CompletedTask;
    }
}
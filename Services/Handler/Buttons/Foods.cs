using bot.Helpers;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace fastfood_order.Services;

public partial class BotUpdateHandler
{
    public string[] ContinueButton => new string[]
    {
        "Davom etish"
    };
    public static string[] DisplayDrinks => new string[]
    {
        "CocaCola",
        "Pepsi",
        "Sharbat",
        "Haridni davom etish",
        "Ortga"
    };
    private async Task Foods(ITelegramBotClient botClient, Message message, CancellationToken token, int selectedHotdogNumber)
   {

        var countOfStep = await _userService.GetStepOfOrder(message.Chat.Id) ?? 0;

        if(countOfStep == 0)
        {
            await botClient.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: $"{selectedHotdogNumber} FastFood haqida ma'lumot chiqadi",
                parseMode: ParseMode.Html,
                cancellationToken: token
            );
        }

        await _userService.UpdateStepOfOrder(message.Chat.Id, countOfStep+1);

        await FoodCount(botClient, message, token, selectedHotdogNumber);
   } 
   private async Task Drinks(ITelegramBotClient botClient, Message message, CancellationToken token)
   {

        await botClient.SendTextMessageAsync(
            chatId: message.Chat.Id,
            text: $"Ichimlik haqida ma'lumot chiqadi",
            replyMarkup: MarkupHelpers.GetReplyKeyboardMarkup(DisplayDrinks, 2),
            parseMode: ParseMode.Html,
            cancellationToken: token
        );
   } 
}
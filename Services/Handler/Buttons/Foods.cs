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
        _localizer["next"],
        _localizer["continue-shopping"]
    };
    public string[] DisplayDrinks => new string[]
    {
        "CocaCola",
        "Pepsi",
        _localizer["juice"],
        _localizer["back"],
        _localizer["continue-shopping"]
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

        await OnOrderedFood(botClient, message, token);
   } 
   private async Task Drinks(ITelegramBotClient botClient, Message message, CancellationToken token)
   {

        await botClient.SendTextMessageAsync(
            chatId: message.Chat.Id,
            text: $"{_localizer["choose-drink"]}",
            replyMarkup: MarkupHelpers.GetReplyKeyboardMarkup(DisplayDrinks, 2),
            parseMode: ParseMode.Html,
            cancellationToken: token
        );
   } 

   private async Task OnOrderedFood(ITelegramBotClient botClient, Message message, CancellationToken token)
   {

        await botClient.SendTextMessageAsync(
            chatId: message.Chat.Id,
            text: _localizer["shopping"],
            replyMarkup: MarkupHelpers.GetReplyKeyboardMarkup(ContinueButton, 2),
            parseMode: ParseMode.Html,
            cancellationToken: token
        );
   } 
}
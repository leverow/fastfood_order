using bot.Helpers;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace fastfood_order.Services;

public partial class BotUpdateHandler
{
     public string[] DisplayTakeFood => new string[]
    {
        "Joylashuvni jo'natish"
    };

    private async Task TakeFood(ITelegramBotClient botClient, Message? message, CancellationToken token)
    {
        await botClient.SendTextMessageAsync(
            chatId: message.Chat.Id,
            text: "Buyurtma haqida ma'lumot chiqadi",
            replyMarkup: MarkupHelpers.GetReplyKeyboardMarkup(DisplayTakeFood, 2),
            parseMode: ParseMode.Html,
            cancellationToken: token
        );
    }
}
using bot.Constants;
using bot.Helpers;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace fastfood_order.Services;

public partial class BotUpdateHandler
{
    private async Task TakeFood(ITelegramBotClient botClient, Message? message, CancellationToken token)
    {
        await botClient.SendTextMessageAsync(
            chatId: message.Chat.Id,
            text: "Buyurtma haqida ma'lumot chiqadi",
            replyMarkup: MarkupHelpers.GetReplyKeyboardMarkup(StringConstants.TakeFood.Values.ToArray(), 3),
            parseMode: ParseMode.Html,
            cancellationToken: token
        );
    }
}
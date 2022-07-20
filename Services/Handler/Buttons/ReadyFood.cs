using bot.Helpers;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace fastfood_order.Services;

public partial class BotUpdateHandler
{
    public string[] DisplayReadyFood => new string[]
    {
        _localizer["continue-shopping"],
        _localizer["buy"],
    };
    private async Task ReadyFood(ITelegramBotClient botClient, Message? message, CancellationToken token)
    {
        
        await botClient.SendTextMessageAsync(
            chatId: message.Chat.Id,
            text: "Buyurtma haqida ma'lumot chiqadi",
            replyMarkup: MarkupHelpers.GetReplyKeyboardMarkup(DisplayReadyFood, 2),
            parseMode: ParseMode.Html,
            cancellationToken: token
        );
    }
}
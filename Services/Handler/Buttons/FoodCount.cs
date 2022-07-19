using bot.Helpers;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace fastfood_order.Services;

public partial class BotUpdateHandler
{
    public Dictionary<string, string> FoodssCount => new()
    {
        { "ayirish", "-1" },
        { "ikkita", "1" },
        { "qoshish", "+1" },
    };
    private async Task FoodCount(ITelegramBotClient botClient, Message? message, CancellationToken token)
    {
        
        await botClient.SendTextMessageAsync(
            chatId: message.Chat.Id,
            text: "Sonini kiriting",
            replyMarkup: MarkupHelpers.GetInlineKeyboardMatrix(FoodssCount, 3),
            parseMode: ParseMode.Html,
            cancellationToken: token
        );
    }
}
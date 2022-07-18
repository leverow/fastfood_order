using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace fastfood_order.Services;

public partial class BotUpdateHandler
{
    private static async Task SendLocation(ITelegramBotClient botClient, Message message, CancellationToken token)
    {
        await botClient.SendTextMessageAsync(
            chatId: message.Chat.Id,
            text: "Locatsiyamni jo'nat",
            replyMarkup: CreateLocationRequestButton("Locatsiyamni jo'nat"));
    }

    public static ReplyKeyboardMarkup CreateLocationRequestButton(string title)
    {
        ReplyKeyboardMarkup replyKeyboardMarkup = new(
            new[]
            {
                KeyboardButton.WithRequestLocation(title),
            })
            {
                ResizeKeyboard = true
            };

        return replyKeyboardMarkup;
    }
}
 
 
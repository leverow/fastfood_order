using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace fastfood_order.Services;

public partial class BotUpdateHandler
{
    private async Task GetNumber(ITelegramBotClient botClient, Message message, CancellationToken token)
    {
        await botClient.SendTextMessageAsync(
            chatId: message.Chat.Id,
            text: _localizer["phone-Number"],
            replyMarkup: CreateContactRequestButton(_localizer["send"]));
    }

    public static ReplyKeyboardMarkup CreateContactRequestButton(string title)
    {
        ReplyKeyboardMarkup replyKeyboardMarkup = new(
            new[]
            {
                KeyboardButton.WithRequestContact(title),
            })
            {
                ResizeKeyboard = true
            };

        return replyKeyboardMarkup;
    }
}
 
 
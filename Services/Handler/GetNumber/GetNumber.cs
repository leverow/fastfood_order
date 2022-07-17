using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace fastfood_order.Services;

public partial class BotUpdateHandler
{
    private static async Task GetNumber(ITelegramBotClient botClient, Message message, CancellationToken token)
    {       
        const string usage = "Iltimos telefon raqamingizni jo'nating";

        await botClient.SendTextMessageAsync(chatId: message.Chat.Id,
                                                    text: usage,
                                                    replyMarkup: new ReplyKeyboardRemove());

        await botClient.SendTextMessageAsync(chatId: message.Chat.Id,
                                                    text: "Raqamni jo'natish",
                                                    replyMarkup: CreateContactRequestButton("Telefon raqamni ulashish")
                                                    );
    }

    public static ReplyKeyboardMarkup CreateContactRequestButton(string title)
    {
        ReplyKeyboardMarkup requestReplyKeyboard = new(
            new[]
            {
            KeyboardButton.WithRequestContact(title),
            
            })
            {
                ResizeKeyboard = true
            };
        return requestReplyKeyboard;
    }
}
 
 
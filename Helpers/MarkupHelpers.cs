using Telegram.Bot.Types.ReplyMarkups;

namespace bot.Helpers;

public static class MarkupHelpers
{
    public static ReplyKeyboardMarkup GetReplyKeyboardMarkup(string[] keys, int columns = 2)
    {
        var buttons = keys.Select(k => new KeyboardButton(k));
        return new ReplyKeyboardMarkup(buttons)
        {
            ResizeKeyboard = true
        };
    }
}
using bot.Helpers;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace fastfood_order.Services;

public partial class BotUpdateHandler
{
    private async Task ChangeLanguage(ITelegramBotClient botClient, Message? message, CancellationToken token)
    {
        
        await botClient.SendTextMessageAsync(
            chatId: message.Chat.Id,
            text: $"{_localizer["choose-language"]}",
            replyMarkup: MarkupHelpers.GetReplyKeyboardMarkup(LanguageNames.Values.ToArray(), 2),
            parseMode: ParseMode.Html,
            cancellationToken: token
        );
    }
}
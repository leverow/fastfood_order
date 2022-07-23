using bot.Helpers;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace fastfood_order.Services;

public partial class BotUpdateHandler
{ 
    private async Task AboutUs(ITelegramBotClient botClient, Message message, CancellationToken token)
   {
        var about = $"{_localizer["bot-about"]}";
 
        await botClient.SendTextMessageAsync(
            chatId: message.Chat.Id,
            text: $"{_localizer["bot-about"]}",
            replyMarkup: MarkupHelpers.GetReplyKeyboardMarkup(MainMenu, 2),
            // parseMode: ParseMode.Markdown,
            cancellationToken: token
        );
   } 
}
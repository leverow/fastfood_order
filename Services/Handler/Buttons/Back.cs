using bot.Helpers;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace fastfood_order.Services;

public partial class BotUpdateHandler
{
    private async Task ReplyMarkupBackKeyboard(ITelegramBotClient botClient, Message message, CancellationToken token)
   {
        await MainButtons(botClient, message, token);
   } 
}
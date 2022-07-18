using bot.Constants;
using bot.Helpers;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace fastfood_order.Services;

public partial class BotUpdateHandler
{
    private async Task AboutUs(ITelegramBotClient botClient, Message message, CancellationToken token)
   {
        var about = "Botimiz palonchi fastfood tayyorlaydigan muassassaga tegishli, \n\n U orqali qorningizni to'ydiring \n\n A'loqa: +998-88-888-88-88 \n Admin: @AbdulazizDeveloper";

        await botClient.SendTextMessageAsync(
            chatId: message.Chat.Id,
            text: $"{about}",
            replyMarkup: MarkupHelpers.GetReplyKeyboardMarkup(StringConstants.MainMenu.Values.ToArray(), 3),
            parseMode: ParseMode.Html,
            cancellationToken: token
        );
   } 
}
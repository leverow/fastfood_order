using bot.Helpers;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace fastfood_order.Services;

public partial class BotUpdateHandler
{

    public string[] MainMenu => new string[]
    {
        _localizer["to-order"],
        _localizer["settings"],       
        _localizer["our-information"],
    };
    private async Task MainButtons(ITelegramBotClient botClient, Message? message, CancellationToken token)
    {
        await botClient.SendTextMessageAsync(
            chatId: message.Chat.Id,
            text: _localizer["main-menu"],
            replyMarkup: MarkupHelpers.GetReplyKeyboardMarkup(MainMenu, 2),
            parseMode: ParseMode.Html,
            cancellationToken: token
        );
    }
}
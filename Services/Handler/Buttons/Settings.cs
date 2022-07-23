using bot.Helpers;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace fastfood_order.Services;

public partial class BotUpdateHandler
{
    public string[] SettingButtons => new string[]
    {
        _localizer["choose-language"],
        _localizer["back"],
    };
    private async Task Settings(ITelegramBotClient botClient, Message message, CancellationToken token)
   {

        await botClient.SendTextMessageAsync(
            chatId: message.Chat.Id,
            text: _localizer["choose-setting"],
            replyMarkup: MarkupHelpers.GetReplyKeyboardMarkup(SettingButtons,2),
            parseMode: ParseMode.Html,
            cancellationToken: token
        );
        
   }
}
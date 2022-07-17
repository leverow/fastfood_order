using Telegram.Bot;
using Telegram.Bot.Types;

namespace fastfood_order.Services.Handler;

public static class UserFullname
{
    public async static Task TakeFullname(ITelegramBotClient botClient, Message? message, CancellationToken token)
    {

        await botClient.SendTextMessageAsync(
            chatId: message.Chat.Id,
            text: "Iltimos Ism familiyangizni kiriting",
            cancellationToken: token);        
    }
}
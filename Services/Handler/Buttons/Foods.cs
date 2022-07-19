using bot.Helpers;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace fastfood_order.Services;

public partial class BotUpdateHandler
{
    public static string[] DisplayDrinks => new string[]
    {
        "CocaCola",
        "Pepsi",
        "Sharbat",
        "Haridni davom etish",
        "Ortga"
    };
    // public static Dictionary<string,string> DisplayFoods => new()
    // {
    //     {"sausage","Sosiska"},
    //     {"cheese","Sir xoxland"},
    //     {"turkey","Indeyka"},
    //     {"beef","Govyadina"},
    //     {"baloneziya","Baloneziya sous"}
    // };
    private async Task Foods(ITelegramBotClient botClient, Message message, CancellationToken token)
   {
        var sausage = await _userService.GetExtraSausageAsync(message.From.Id);
        var cheese = await _userService.GetExtraCheeseAsync(message.From.Id);
        var beef = await _userService.GetExtraBeefAsync(message.From.Id);
        var turkey = await _userService.GetExtraTurkeyAsync(message.From.Id);
        var balonesia = await _userService.GetExtraBalonesiaAsync(message.From.Id);

        await botClient.SendTextMessageAsync(
            chatId: message.Chat.Id,
            text: "ReplyMarkup uchun yozuv (Davom etish)ni chiqarish uchun",
            replyMarkup: MarkupHelpers.GetReplyKeyboardMarkup(ContinueButton,1),
            cancellationToken: token
        );

        await botClient.SendTextMessageAsync(
            chatId: message.Chat.Id,
            text: $"FastFood haqida ma'lumot chiqadi",
            replyMarkup: MarkupHelpers.GetInlineKeyboardMatrix(new()
            {
                {"sausage",$"Sosiska {sausage}"},
                {"cheese",$"Sir xoxland {cheese}"},
                {"turkey",$"Indeyka {turkey}"},
                {"beef",$"Govyadina {beef}"},
                {"baloneziya",$"Baloneziya sous {balonesia}"}
            }, 3),
            parseMode: ParseMode.Html,
            cancellationToken: token
        );
   } 
   private async Task Drinks(ITelegramBotClient botClient, Message message, CancellationToken token)
   {

        await botClient.SendTextMessageAsync(
            chatId: message.Chat.Id,
            text: $"Ichimlik haqida ma'lumot chiqadi",
            replyMarkup: MarkupHelpers.GetReplyKeyboardMarkup(DisplayDrinks, 3),
            parseMode: ParseMode.Html,
            cancellationToken: token
        );
   } 
}
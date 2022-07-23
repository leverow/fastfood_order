using bot.Helpers;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace fastfood_order.Services;

public partial class BotUpdateHandler
{
    public string[] FoodNames => new string[]{
        "Americano hot-dog 🌭",
        "Classic hot-dog 🌭",
        "Double hot-dog 🌭",
        "Meat hot-dog 🌭",
        "Franch hot-dog 🌭" ,
        // _localizer["drinks"],
        _localizer["back"]
    }; 
    private async Task MenuOfHotdogs(ITelegramBotClient botClient, Message message, CancellationToken token)
   {
        await botClient.SendPhotoAsync(
            message.Chat.Id,
            photo: "https://i.imgur.com/flIcOby.jpg",
            caption: _localizer["menu-hotdog"],
            replyMarkup: MarkupHelpers.GetReplyKeyboardMarkup(FoodNames));
   } 
}
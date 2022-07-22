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
        "Ichimliklar",
        _localizer["back"]
    }; 
    private async Task MenuOfHotdogs(ITelegramBotClient botClient, Message message, CancellationToken token)
   {
        await botClient.SendPhotoAsync(
            message.Chat.Id,
            photo: "https://i.imgur.com/flIcOby.jpg",
            caption: "Menu of Hot dogs",
            replyMarkup: MarkupHelpers.GetReplyKeyboardMarkup(FoodNames));
   } 
}
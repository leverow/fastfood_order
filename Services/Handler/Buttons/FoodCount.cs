using bot.Helpers;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace fastfood_order.Services;

public partial class BotUpdateHandler
{
    // public Dictionary<string, string> FoodsCount => ;
    private async Task FoodCount(ITelegramBotClient botClient, Message message, CancellationToken token, int selectedHotdogNumber)
    {
        ArgumentNullException.ThrowIfNull(message);

        var amountOfHotdog = selectedHotdogNumber switch
        {
            1 => await _userService.GetAmericanoHotdogAsync(userId: message.Chat.Id),
            2 => await _userService.GetDoubleHotdogAsync(userId: message.Chat.Id),
            3 => await _userService.GetFranchHotdogAsync(userId: message.Chat.Id),
            4 => await _userService.GetMeatHotdogAsync(userId: message.Chat.Id),
            5 => await _userService.GetClassicHotdogAsync(userId: message.Chat.Id),
            _ => 0
        };

        await botClient.SendTextMessageAsync(
            chatId: message.Chat.Id,
            text: _localizer["food-count"],
            replyMarkup: MarkupHelpers.GetInlineKeyboardMatrix(new()
            {
                { $"ayirish_{selectedHotdogNumber}", "➖" },
                { "emptyData", amountOfHotdog.ToString()},
                { $"qoshish_{selectedHotdogNumber}", "➕" },
            }, 3),
            parseMode: ParseMode.Html,
            cancellationToken: token
        );
            // if(message.Text.All(char.IsDigit))
            // {
            //     var handler = selectedHotdogNumber switch
            //     {
            //         1 => _userService.AddHotDogAsync(userId: message.Chat.Id, americano_hot_dog: 1),
            //         2 => _userService.AddHotDogAsync(userId: message.Chat.Id, double_hot_dog: 1),
            //         3 => _userService.AddHotDogAsync(userId: message.Chat.Id, franch_hot_dog: 1),
            //         4 => _userService.AddHotDogAsync(userId: message.Chat.Id, meat_hot_dog: 1),
            //         5 => _userService.AddHotDogAsync(userId: message.Chat.Id, classic_hot_dog: 1),

            //         _ => _userService.AddHotDogAsync(userId: message.Chat.Id, 0, 0, 0, 0, 0)
            //     };

            //     await handler;

            // }
        // }
    }
}